using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Teachers.Homework
{
    public class GetHomeworksQuery : IRequest<List<HomeworkDto>>
    {
        public int TeacherId { get; set; }
        public int? ClassId { get; set; }
        public int? SubjectId { get; set; }
    }

    public class GetHomeworksQueryHandler : IRequestHandler<GetHomeworksQuery, List<HomeworkDto>>
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetHomeworksQueryHandler(IHomeworkRepository homeworkRepository, ITeacherRepository teacherRepository)
        {
            _homeworkRepository = homeworkRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<HomeworkDto>> Handle(GetHomeworksQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher exists
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var homeworks = await _homeworkRepository.GetHomeworksByTeacherAsync(
                request.TeacherId, request.ClassId, request.SubjectId);

            return homeworks.Select(h => new HomeworkDto
            {
                Id = h.Id,
                Title = h.Title,
                Description = h.Description,
                ClassId = h.ClassId,
                ClassName = h.Class?.Name ?? "Unknown",
                SubjectId = h.SubjectId,
                SubjectName = h.Subject?.Name ?? "Unknown",
                DueDate = h.DueDate,
                CreatedAt = h.CreatedAt,
                Materials = h.Materials?.Select(m => new HomeworkMaterialDto
                {
                    Id = m.Id,
                    FileName = m.FileName,
                    FileUrl = m.FileUrl,
                    FileType = m.FileType
                }).ToList() ?? new List<HomeworkMaterialDto>()
            }).ToList();
        }
    }

    public class HomeworkDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
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