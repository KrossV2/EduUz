using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Teachers.Grades
{
    public class GetClassGradesQuery : IRequest<List<GradeDto>>
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
    }

    public class GetClassGradesQueryHandler : IRequestHandler<GetClassGradesQuery, List<GradeDto>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetClassGradesQueryHandler(IGradeRepository gradeRepository, ITeacherRepository teacherRepository)
        {
            _gradeRepository = gradeRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<GradeDto>> Handle(GetClassGradesQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this class
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToClassAsync(request.TeacherId, request.ClassId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this class");

            var grades = await _gradeRepository.GetGradesByClassAsync(request.ClassId);
            return grades.Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                StudentName = g.Student?.FullName ?? "Unknown",
                SubjectId = g.SubjectId,
                SubjectName = g.Subject?.Name ?? "Unknown",
                GradeType = g.GradeType,
                Value = g.Value,
                Date = g.Date,
                Comment = g.Comment
            }).ToList();
        }
    }

    public class GradeDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public GradeType GradeType { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
    }

    public enum GradeType
    {
        Daily = 1,
        Control = 2,
        Quarter = 3,
        Yearly = 4
    }
}