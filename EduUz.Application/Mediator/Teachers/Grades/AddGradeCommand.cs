using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Grades
{
    public class AddGradeCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public GradeType GradeType { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }

    public class AddGradeCommandHandler : IRequestHandler<AddGradeCommand, int>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public AddGradeCommandHandler(
            IGradeRepository gradeRepository, 
            ITeacherRepository teacherRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _gradeRepository = gradeRepository;
            _teacherRepository = teacherRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<int> Handle(AddGradeCommand request, CancellationToken cancellationToken)
        {
            // Validate grade value
            if (request.Value < 1 || request.Value > 5)
                throw new ArgumentException("Grade value must be between 1 and 5");

            // Check if teacher has access to this student and subject
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToStudentAndSubjectAsync(
                request.TeacherId, request.StudentId, request.SubjectId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this student and subject");

            // Create grade
            var grade = new Grade
            {
                StudentId = request.StudentId,
                SubjectId = request.SubjectId,
                TeacherId = request.TeacherId,
                GradeType = request.GradeType,
                Value = request.Value,
                Date = request.Date,
                Comment = request.Comment,
                CreatedAt = DateTime.UtcNow
            };

            var gradeId = await _gradeRepository.AddAsync(grade);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddGrade",
                Description = $"Added grade {request.Value} for student {request.StudentId} in subject {request.SubjectId}",
                CreatedAt = DateTime.UtcNow
            });

            return gradeId;
        }
    }
}