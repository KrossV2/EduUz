using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Students
{
    public class GetMyHomeworksQuery : IRequest<List<MyHomeworkDto>>
    {
        public int StudentId { get; set; }
        public int? SubjectId { get; set; }
        public bool? IsCompleted { get; set; }
    }

    public class GetMyHomeworksQueryHandler : IRequestHandler<GetMyHomeworksQuery, List<MyHomeworkDto>>
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IStudentRepository _studentRepository;

        public GetMyHomeworksQueryHandler(IHomeworkRepository homeworkRepository, IStudentRepository studentRepository)
        {
            _homeworkRepository = homeworkRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<MyHomeworkDto>> Handle(GetMyHomeworksQuery request, CancellationToken cancellationToken)
        {
            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new UnauthorizedAccessException("Student not found");

            var homeworks = await _homeworkRepository.GetHomeworksByClassAsync(
                student.ClassId, request.SubjectId);

            var result = new List<MyHomeworkDto>();

            foreach (var homework in homeworks)
            {
                var submission = await _homeworkRepository.GetHomeworkSubmissionAsync(
                    homework.Id, request.StudentId);

                result.Add(new MyHomeworkDto
                {
                    Id = homework.Id,
                    Title = homework.Title,
                    Description = homework.Description,
                    SubjectId = homework.SubjectId,
                    SubjectName = homework.Subject.Name,
                    TeacherName = homework.Teacher.FullName,
                    DueDate = homework.DueDate,
                    CreatedAt = homework.CreatedAt,
                    IsCompleted = submission != null,
                    SubmittedAt = submission?.SubmittedAt,
                    Materials = homework.Materials.Select(m => new HomeworkMaterialDto
                    {
                        Id = m.Id,
                        FileName = m.FileName,
                        FileUrl = m.FileUrl,
                        FileType = m.FileType
                    }).ToList()
                });
            }

            if (request.IsCompleted.HasValue)
            {
                result = result.Where(h => h.IsCompleted == request.IsCompleted.Value).ToList();
            }

            return result;
        }
    }

    public class MyHomeworkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? SubmittedAt { get; set; }
        public List<HomeworkMaterialDto> Materials { get; set; }
    }

    public class HomeworkMaterialDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
    }
}