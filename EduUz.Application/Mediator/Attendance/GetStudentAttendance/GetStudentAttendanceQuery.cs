using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Attendance.GetStudentAttendance;

public class GetStudentAttendanceQuery(int studentId) : IRequest<List<Core.Models.Attendance>>
{
    public int StudentId { get; set; } = studentId;
}

public class GetStudentAttendanceQueryHandler(IAttendanceRepository repo) : IRequestHandler<GetStudentAttendanceQuery, List<Core.Models.Attendance>>
{
    public async Task<List<Core.Models.Attendance>> Handle(GetStudentAttendanceQuery request, CancellationToken cancellationToken)
    {
        var attendances = repo.GetAll()
            .Where(a => a.StudentId == request.StudentId)
            .ToList();
        
        return attendances;
    }
}