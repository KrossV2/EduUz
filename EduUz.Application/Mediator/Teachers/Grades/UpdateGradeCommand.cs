using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Grades
{
    public class UpdateGradeCommand : IRequest<bool>
    {
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        public int NewValue { get; set; }
        public string Reason { get; set; }
    }

    public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand, bool>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IGradeChangeRequestRepository _gradeChangeRequestRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public UpdateGradeCommandHandler(
            IGradeRepository gradeRepository,
            ITeacherRepository teacherRepository,
            IDirectorRepository directorRepository,
            IGradeChangeRequestRepository gradeChangeRequestRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _gradeRepository = gradeRepository;
            _teacherRepository = teacherRepository;
            _directorRepository = directorRepository;
            _gradeChangeRequestRepository = gradeChangeRequestRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<bool> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
        {
            // Validate grade value
            if (request.NewValue < 1 || request.NewValue > 5)
                throw new ArgumentException("Grade value must be between 1 and 5");

            // Get the grade
            var grade = await _gradeRepository.GetByIdAsync(request.GradeId);
            if (grade == null)
                throw new ArgumentException("Grade not found");

            // Check if teacher has access to this grade
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            if (grade.TeacherId != request.TeacherId)
                throw new UnauthorizedAccessException("Teacher can only update their own grades");

            // Get director for the school
            var director = await _directorRepository.GetBySchoolIdAsync(teacher.SchoolId);
            if (director == null)
                throw new ArgumentException("Director not found for this school");

            // Create grade change request
            var changeRequest = new GradeChangeRequest
            {
                GradeId = request.GradeId,
                TeacherId = request.TeacherId,
                DirectorId = director.Id,
                OldValue = grade.Value,
                NewValue = request.NewValue,
                Reason = request.Reason,
                Status = GradeChangeStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _gradeChangeRequestRepository.AddAsync(changeRequest);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "RequestGradeChange",
                Description = $"Requested grade change from {grade.Value} to {request.NewValue} for grade {request.GradeId}. Reason: {request.Reason}",
                CreatedAt = DateTime.UtcNow
            });

            return true;
        }
    }

    public enum GradeChangeStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}