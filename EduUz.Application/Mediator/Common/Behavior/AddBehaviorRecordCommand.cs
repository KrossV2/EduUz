using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Common.Behavior
{
    public class AddBehaviorRecordCommand : IRequest<int>
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public BehaviorType Type { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Evidence { get; set; } // Optional evidence/documentation
    }

    public class AddBehaviorRecordCommandHandler : IRequestHandler<AddBehaviorRecordCommand, int>
    {
        private readonly IBehaviorRecordRepository _behaviorRecordRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;
        private readonly INotificationService _notificationService;

        public AddBehaviorRecordCommandHandler(
            IBehaviorRecordRepository behaviorRecordRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            IActivityHistoryRepository activityHistoryRepository,
            INotificationService notificationService)
        {
            _behaviorRecordRepository = behaviorRecordRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _activityHistoryRepository = activityHistoryRepository;
            _notificationService = notificationService;
        }

        public async Task<int> Handle(AddBehaviorRecordCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher exists
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new ArgumentException("Student not found");

            // Check if teacher has access to this student
            var hasAccess = await _teacherRepository.HasAccessToStudentAsync(request.TeacherId, request.StudentId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this student");

            // Validate points based on behavior type
            if (request.Type == BehaviorType.Positive && request.Points <= 0)
                throw new ArgumentException("Positive behavior must have positive points");
            if (request.Type == BehaviorType.Negative && request.Points >= 0)
                throw new ArgumentException("Negative behavior must have negative points");

            // Create behavior record
            var behaviorRecord = new BehaviorRecord
            {
                StudentId = request.StudentId,
                TeacherId = request.TeacherId,
                Type = request.Type,
                Points = request.Points,
                Description = request.Description,
                Date = request.Date,
                Evidence = request.Evidence,
                CreatedAt = DateTime.UtcNow
            };

            var recordId = await _behaviorRecordRepository.AddAsync(behaviorRecord);

            // Update student's total behavior points
            var totalPoints = await _behaviorRecordRepository.GetTotalBehaviorPointsAsync(request.StudentId);
            student.TotalBehaviorPoints = totalPoints;
            await _studentRepository.UpdateAsync(student);

            // Notify parents if negative behavior
            if (request.Type == BehaviorType.Negative)
            {
                var parents = await _studentRepository.GetParentsByStudentIdAsync(request.StudentId);
                foreach (var parent in parents)
                {
                    await _notificationService.SendEmailAsync(
                        parent.Email,
                        "Behavior Notice",
                        $"Your child {student.FullName} has received a behavior record: {request.Description}. Points: {request.Points}"
                    );
                }
            }

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddBehaviorRecord",
                Description = $"Added {request.Type} behavior record for student {student.FullName}. Points: {request.Points}",
                CreatedAt = DateTime.UtcNow
            });

            return recordId;
        }
    }

    public enum BehaviorType
    {
        Positive = 1,
        Negative = 2
    }
}