using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Parents
{
    public class GetChildGradesQuery : IRequest<List<ChildGradeDto>>
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int? SubjectId { get; set; }
        public GradeType? GradeType { get; set; }
    }

    public class GetChildGradesQueryHandler : IRequestHandler<GetChildGradesQuery, List<ChildGradeDto>>
    {
        private readonly IParentRepository _parentRepository;
        private readonly IGradeRepository _gradeRepository;

        public GetChildGradesQueryHandler(IParentRepository parentRepository, IGradeRepository gradeRepository)
        {
            _parentRepository = parentRepository;
            _gradeRepository = gradeRepository;
        }

        public async Task<List<ChildGradeDto>> Handle(GetChildGradesQuery request, CancellationToken cancellationToken)
        {
            // Check if parent has access to this child
            var parentChildLink = await _parentRepository.GetParentStudentLinkAsync(request.ParentId, request.ChildId);
            if (parentChildLink == null)
                throw new UnauthorizedAccessException("Parent does not have access to this child");

            var grades = await _gradeRepository.GetGradesByStudentAsync(
                request.ChildId, request.SubjectId, request.GradeType);

            return grades.Select(g => new ChildGradeDto
            {
                Id = g.Id,
                SubjectId = g.SubjectId,
                SubjectName = g.Subject.Name,
                GradeType = g.GradeType,
                Value = g.Value,
                Date = g.Date,
                Comment = g.Comment,
                TeacherName = g.Teacher.FullName
            }).ToList();
        }
    }

    public class ChildGradeDto
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public GradeType GradeType { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string TeacherName { get; set; }
    }
}