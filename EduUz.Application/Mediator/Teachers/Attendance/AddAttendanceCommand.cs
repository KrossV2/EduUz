using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Attendance
{
    public class AddAttendanceCommand : IRequest<bool>
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public DateTime Date { get; set; }
        public List<AttendanceRecord> Records { get; set; }
    }

    public class AttendanceRecord
    {
        public int StudentId { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Comment { get; set; }
    }

    public class AddAttendanceCommandHandler : IRequestHandler<AddAttendanceCommand, bool>
    {
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IParentRepository _parentRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;
        private readonly INotificationService _notificationService;

        public AddAttendanceCommandHandler(
            IAttendanceRepository attendanceRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            IParentRepository parentRepository,
            IActivityHistoryRepository activityHistoryRepository,
            INotificationService notificationService)
        {
            _attendanceRepository = attendanceRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _parentRepository = parentRepository;
            _activityHistoryRepository = activityHistoryRepository;
            _notificationService = notificationService;
        }

        public async Task<bool> Handle(AddAttendanceCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher has access to this class
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var hasAccess = await _teacherRepository.HasAccessToClassAsync(request.TeacherId, request.ClassId);
            if (!hasAccess)
                throw new UnauthorizedAccessException("Teacher does not have access to this class");

            var attendanceRecords = new List<Attendance>();
            var absentStudents = new List<int>();

            foreach (var record in request.Records)
            {
                var attendance = new Attendance
                {
                    StudentId = record.StudentId,
                    ClassId = request.ClassId,
                    Date = request.Date,
                    Status = record.Status,
                    Comment = record.Comment,
                    CreatedAt = DateTime.UtcNow
                };

                attendanceRecords.Add(attendance);

                if (record.Status == AttendanceStatus.Absent)
                {
                    absentStudents.Add(record.StudentId);
                }
            }

            await _attendanceRepository.AddRangeAsync(attendanceRecords);

            // Check for consecutive absences and notify parents
            foreach (var studentId in absentStudents)
            {
                var consecutiveAbsences = await _attendanceRepository.GetConsecutiveAbsencesAsync(studentId);
                if (consecutiveAbsences >= 3) // Notify after 3 consecutive absences
                {
                    var parents = await _parentRepository.GetParentsByStudentIdAsync(studentId);
                    var student = await _studentRepository.GetByIdAsync(studentId);

                    foreach (var parent in parents)
                    {
                        await _notificationService.SendEmailAsync(
                            parent.Email,
                            "Student Absence Notification",
                            $"Your child {student.FullName} has been absent for {consecutiveAbsences} consecutive days without excuse."
                        );
                    }
                }
            }

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddAttendance",
                Description = $"Added attendance for class {request.ClassId} on {request.Date:yyyy-MM-dd}",
                CreatedAt = DateTime.UtcNow
            });

            return true;
        }
    }
}