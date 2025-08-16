using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Homework
{
    public class AddHomeworkCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public List<HomeworkMaterial> Materials { get; set; }
    }

    public class HomeworkMaterial
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
    }

    public class AddHomeworkCommandHandler : IRequestHandler<AddHomeworkCommand, int>
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public AddHomeworkCommandHandler(
            IHomeworkRepository homeworkRepository,
            ITeacherRepository teacherRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _homeworkRepository = homeworkRepository;
            _teacherRepository = teacherRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<int> Handle(AddHomeworkCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this class and subject
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToClassAndSubjectAsync(
                request.TeacherId, request.ClassId, request.SubjectId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this class and subject");

            // Create homework
            var homework = new Homework
            {
                TeacherId = request.TeacherId,
                ClassId = request.ClassId,
                SubjectId = request.SubjectId,
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                CreatedAt = DateTime.UtcNow
            };

            var homeworkId = await _homeworkRepository.AddAsync(homework);

            // Add materials if any
            if (request.Materials != null && request.Materials.Any())
            {
                var materials = request.Materials.Select(m => new HomeworkMaterial
                {
                    HomeworkId = homeworkId,
                    FileName = m.FileName,
                    FileUrl = m.FileUrl,
                    FileType = m.FileType,
                    CreatedAt = DateTime.UtcNow
                }).ToList();

                await _homeworkRepository.AddMaterialsAsync(materials);
            }

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddHomework",
                Description = $"Added homework '{request.Title}' for class {request.ClassId}",
                CreatedAt = DateTime.UtcNow
            });

            return homeworkId;
        }
    }
}