using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Attendance
{
    public class GetStudentAttendanceQuery : IRequest<List<AttendanceDto>>
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class GetStudentAttendanceQueryHandler : IRequestHandler<GetStudentAttendanceQuery, List<AttendanceDto>>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ITeacherRepository _teacherRepository;

        public GetStudentAttendanceQueryHandler(IAttendanceRepository attendanceRepository, ITeacherRepository teacherRepository)
        {
            _attendanceRepository = attendanceRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<List<AttendanceDto>> Handle(GetStudentAttendanceQuery request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this student
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToStudentAsync(request.TeacherId, request.StudentId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this student");

            var attendance = await _attendanceRepository.GetAttendanceByStudentAsync(
                request.StudentId, request.StartDate, request.EndDate);
            
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
}