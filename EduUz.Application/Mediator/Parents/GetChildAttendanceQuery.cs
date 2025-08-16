using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Parents
{
    public class GetChildAttendanceQuery : IRequest<List<ChildAttendanceDto>>
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class GetChildAttendanceQueryHandler : IRequestHandler<GetChildAttendanceQuery, List<ChildAttendanceDto>>
    {
        private readonly IParentRepository _parentRepository;
        private readonly IAttendanceRepository _attendanceRepository;

        public GetChildAttendanceQueryHandler(IParentRepository parentRepository, IAttendanceRepository attendanceRepository)
        {
            _parentRepository = parentRepository;
            _attendanceRepository = attendanceRepository;
        }

        public async Task<List<ChildAttendanceDto>> Handle(GetChildAttendanceQuery request, CancellationToken cancellationToken)
        {
            // Check if parent has access to this child
            var parentChildLink = await _parentRepository.GetParentStudentLinkAsync(request.ParentId, request.ChildId);
            if (parentChildLink == null)
                throw new UnauthorizedAccessException("Parent does not have access to this child");

            var attendance = await _attendanceRepository.GetAttendanceByStudentAsync(
                request.ChildId, request.StartDate, request.EndDate);

            return attendance.Select(a => new ChildAttendanceDto
            {
                Id = a.Id,
                Date = a.Date,
                Status = a.Status,
                Comment = a.Comment,
                ClassName = a.Class.Name
            }).ToList();
        }
    }

    public class ChildAttendanceDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Comment { get; set; }
        public string ClassName { get; set; }
    }
}