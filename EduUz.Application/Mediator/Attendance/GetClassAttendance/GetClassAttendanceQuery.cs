using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Attendance.GetClassAttendance;

public class GetClassAttendanceQuery(int classId) : IRequest<List<Core.Models.Attendance>>
{
    public int ClassId { get; set; } = classId;
}

public class GetClassAttendanceQueryHandler(IAttendanceRepository repo) : IRequestHandler<GetClassAttendanceQuery, List<Core.Models.Attendance>>
{
    public async Task<List<Core.Models.Attendance>> Handle(GetClassAttendanceQuery request, CancellationToken cancellationToken)
    {
        var attendances = repo.GetAll()
            .Where(a => a.Student.ClassId == request.ClassId)
            .ToList();
        
        return attendances;
    }
}