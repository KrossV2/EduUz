using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Students
{
    public class SubmitHomeworkCommand : IRequest<bool>
    {
        public int HomeworkId { get; set; }
        public int StudentId { get; set; }
        public string Comment { get; set; }
        public List<HomeworkSubmissionFile> Files { get; set; }
    }

    public class HomeworkSubmissionFile
    {
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
    }

    public class SubmitHomeworkCommandHandler : IRequestHandler<SubmitHomeworkCommand, bool>
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public SubmitHomeworkCommandHandler(
            IHomeworkRepository homeworkRepository,
            IStudentRepository studentRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _homeworkRepository = homeworkRepository;
            _studentRepository = studentRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<bool> Handle(SubmitHomeworkCommand request, CancellationToken cancellationToken)
        {
            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new UnauthorizedAccessException("Student not found");

            // Check if homework exists and is for student's class
            var homework = await _homeworkRepository.GetByIdAsync(request.HomeworkId);
            if (homework == null)
                throw new ArgumentException("Homework not found");

            if (homework.ClassId != student.ClassId)
                throw new UnauthorizedAccessException("Student does not have access to this homework");

            // Check if homework is already submitted
            var existingSubmission = await _homeworkRepository.GetHomeworkSubmissionAsync(
                request.HomeworkId, request.StudentId);
            if (existingSubmission != null)
                throw new ArgumentException("Homework is already submitted");

            // Check if due date has passed
            if (homework.DueDate < DateTime.UtcNow)
                throw new ArgumentException("Homework due date has passed");

            // Create homework submission
            var submission = new HomeworkSubmission
            {
                HomeworkId = request.HomeworkId,
                StudentId = request.StudentId,
                Comment = request.Comment,
                SubmittedAt = DateTime.UtcNow
            };

            var submissionId = await _homeworkRepository.AddSubmissionAsync(submission);

            // Add submission files if any
            if (request.Files != null && request.Files.Any())
            {
                var files = request.Files.Select(f => new HomeworkSubmissionFile
                {
                    SubmissionId = submissionId,
                    FileName = f.FileName,
                    FileUrl = f.FileUrl,
                    FileType = f.FileType,
                    CreatedAt = DateTime.UtcNow
                }).ToList();

                await _homeworkRepository.AddSubmissionFilesAsync(files);
            }

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.StudentId,
                UserType = UserType.Student,
                Action = "SubmitHomework",
                Description = $"Submitted homework {request.HomeworkId}",
                CreatedAt = DateTime.UtcNow
            });

            return true;
        }
    }
}