using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Students
{
    public class GetMyGradesQuery : IRequest<List<MyGradeDto>>
    {
        public int StudentId { get; set; }
        public int? SubjectId { get; set; }
        public GradeType? GradeType { get; set; }
    }

    public class GetMyGradesQueryHandler : IRequestHandler<GetMyGradesQuery, List<MyGradeDto>>
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IStudentRepository _studentRepository;

        public GetMyGradesQueryHandler(IGradeRepository gradeRepository, IStudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<MyGradeDto>> Handle(GetMyGradesQuery request, CancellationToken cancellationToken)
        {
            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new UnauthorizedAccessException("Student not found");

            var grades = await _gradeRepository.GetGradesByStudentAsync(
                request.StudentId, request.SubjectId, request.GradeType);

            return grades.Select(g => new MyGradeDto
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

    public class MyGradeDto
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