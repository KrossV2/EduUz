using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Students
{
    public class GetMyAttendanceQuery : IRequest<List<MyAttendanceDto>>
    {
        public int StudentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class GetMyAttendanceQueryHandler : IRequestHandler<GetMyAttendanceQuery, List<MyAttendanceDto>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IStudentRepository _studentRepository;

        public GetMyAttendanceQueryHandler(IAttendanceRepository attendanceRepository, IStudentRepository studentRepository)
        {
            _attendanceRepository = attendanceRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<MyAttendanceDto>> Handle(GetMyAttendanceQuery request, CancellationToken cancellationToken)
        {
            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new UnauthorizedAccessException("Student not found");

            var attendance = await _attendanceRepository.GetAttendanceByStudentAsync(
                request.StudentId, request.StartDate, request.EndDate);

            return attendance.Select(a => new MyAttendanceDto
            {
                Id = a.Id,
                Date = a.Date,
                Status = a.Status,
                Comment = a.Comment,
                ClassName = a.Class?.Name ?? "Unknown"
            }).ToList();
        }
    }

    public class MyAttendanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Comment { get; set; }
        public string ClassName { get; set; }
    }
}