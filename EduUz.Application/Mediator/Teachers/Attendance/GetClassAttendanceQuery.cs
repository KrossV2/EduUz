using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Attendance
{
    public class GetClassAttendanceQuery : IRequest<List<AttendanceDto>>
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
    }

    public class GetClassAttendanceQueryHandler : IRequestHandler<GetClassAttendanceQuery, List<AttendanceDto>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetClassAttendanceQueryHandler(IAttendanceRepository attendanceRepository, ITeacherRepository teacherRepository)
        {
            _attendanceRepository = attendanceRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<AttendanceDto>> Handle(GetClassAttendanceQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this class
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToClassAsync(request.TeacherId, request.ClassId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this class");

            var attendance = await _attendanceRepository.GetAttendanceByClassAndDateAsync(request.ClassId, request.Date);
            return attendance.Select(a => new AttendanceDto
            {
                Id = a.Id,
                StudentId = a.StudentId,
                StudentName = a.Student.FullName,
                ClassId = a.ClassId,
                Date = a.Date,
                Status = a.Status,
                Comment = a.Comment
            }).ToList();
        }
    }

    public class AttendanceDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Comment { get; set; }
    }

    public enum AttendanceStatus
    {
        Present = 1,
        Absent = 2,
        Late = 3
    }
}