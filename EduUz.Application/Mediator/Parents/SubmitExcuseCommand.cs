using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Parents
{
    public class SubmitExcuseCommand : IRequest<bool>
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public int AttendanceId { get; set; }
        public string Reason { get; set; }
        public string DocumentUrl { get; set; } // Optional medical certificate or other document
    }

    public class SubmitExcuseCommandHandler : IRequestHandler<SubmitExcuseCommand, bool>
    {
        private readonly IParentRepository _parentRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IExcuseRepository _excuseRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public SubmitExcuseCommandHandler(
            IParentRepository parentRepository,
            IAttendanceRepository attendanceRepository,
            IExcuseRepository excuseRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _parentRepository = parentRepository;
            _attendanceRepository = attendanceRepository;
            _excuseRepository = excuseRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<bool> Handle(SubmitExcuseCommand request, CancellationToken cancellationToken)
        {
            // Check if parent has access to this child
            var parentChildLink = await _parentRepository.GetParentStudentLinkAsync(request.ParentId, request.ChildId);
            if (parentChildLink == null)
                throw new UnauthorizedAccessException("Parent does not have access to this child");

            // Check if attendance record exists and belongs to the child
            var attendance = await _attendanceRepository.GetByIdAsync(request.AttendanceId);
            if (attendance == null)
                throw new ArgumentException("Attendance record not found");

            if (attendance.StudentId != request.ChildId)
                throw new UnauthorizedAccessException("Attendance record does not belong to this child");

            // Check if excuse already exists for this attendance
            var existingExcuse = await _excuseRepository.GetByAttendanceIdAsync(request.AttendanceId);
            if (existingExcuse != null)
                throw new ArgumentException("Excuse already submitted for this attendance");

            // Create excuse
            var excuse = new Excuse
            {
                AttendanceId = request.AttendanceId,
                ParentId = request.ParentId,
                StudentId = request.ChildId,
                Reason = request.Reason,
                DocumentUrl = request.DocumentUrl,
                Status = ExcuseStatus.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _excuseRepository.AddAsync(excuse);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.ParentId,
                UserType = UserType.Parent,
                Action = "SubmitExcuse",
                Description = $"Submitted excuse for attendance {request.AttendanceId}",
                CreatedAt = DateTime.UtcNow
            });

            return true;
        }
    }
}