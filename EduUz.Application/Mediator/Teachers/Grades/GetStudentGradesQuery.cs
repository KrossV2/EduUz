using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Teachers.Grades
{
    public class GetStudentGradesQuery : IRequest<List<GradeDto>>
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
    }

    public class GetStudentGradesQueryHandler : IRequestHandler<GetStudentGradesQuery, List<GradeDto>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetStudentGradesQueryHandler(IGradeRepository gradeRepository, ITeacherRepository teacherRepository)
        {
            _gradeRepository = gradeRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<GradeDto>> Handle(GetStudentGradesQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this student
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToStudentAsync(request.TeacherId, request.StudentId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this student");

            var grades = await _gradeRepository.GetGradesByStudentAsync(request.StudentId);
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
}