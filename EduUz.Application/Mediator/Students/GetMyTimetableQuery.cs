using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Students
{
    public class GetMyTimetableQuery : IRequest<List<MyTimetableDto>>
    {
        public int StudentId { get; set; }
    }

    public class GetMyTimetableQueryHandler : IRequestHandler<GetMyTimetableQuery, List<MyTimetableDto>>
    {
        private readonly ITimetableRepository _timetableRepository;
        private readonly IStudentRepository _studentRepository;

        public GetMyTimetableQueryHandler(ITimetableRepository timetableRepository, IStudentRepository studentRepository)
        {
            _timetableRepository = timetableRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<MyTimetableDto>> Handle(GetMyTimetableQuery request, CancellationToken cancellationToken)
        {
            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new UnauthorizedAccessException("Student not found");

            var timetable = await _timetableRepository.GetTimetableByClassAsync(student.ClassId);

            return timetable.Select(t => new MyTimetableDto
            {
                Id = t.Id,
                DayOfWeek = t.DayOfWeek,
                LessonNumber = t.LessonNumber,
                SubjectId = t.SubjectId,
                SubjectName = t.Subject?.Name ?? "Unknown",
                TeacherId = t.TeacherId,
                TeacherName = t.Teacher?.FullName ?? "Unknown",
                StartTime = t.StartTime,
                EndTime = t.EndTime
            }).ToList();
        }
    }

    public class MyTimetableDto
    {
        public int Id { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int LessonNumber { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}