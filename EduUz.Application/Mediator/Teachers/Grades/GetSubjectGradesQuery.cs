using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Grades
{
    public class GetSubjectGradesQuery : IRequest<List<GradeDto>>
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }

    public class GetSubjectGradesQueryHandler : IRequestHandler<GetSubjectGradesQuery, List<GradeDto>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetSubjectGradesQueryHandler(IGradeRepository gradeRepository, ITeacherRepository teacherRepository)
        {
            _gradeRepository = gradeRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<GradeDto>> Handle(GetSubjectGradesQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this subject
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToSubjectAsync(request.TeacherId, request.SubjectId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this subject");

            var grades = await _gradeRepository.GetGradesBySubjectAsync(request.SubjectId);
            return grades.Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                StudentName = g.Student.FullName,
                SubjectId = g.SubjectId,
                SubjectName = g.Subject.Name,
                GradeType = g.GradeType,
                Value = g.Value,
                Date = g.Date,
                Comment = g.Comment
            }).ToList();
        }
    }
}