using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teacher.Grades.GetGradesByStudent;

public record GetGradesByStudentQuery(int StudentId) : IRequest<List<GradeResponseDto>>;

public class GetGradesByStudentQueryHandler(EduUzDbContext context)
    : IRequestHandler<GetGradesByStudentQuery, List<GradeResponseDto>>
{
    public async Task<List<GradeResponseDto>> Handle(GetGradesByStudentQuery request, CancellationToken cancellationToken)
    {
        return await context.Grades
            .Include(g => g.Student).ThenInclude(s => s.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Teacher).ThenInclude(t => t.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Subject)
            .Where(g => g.StudentId == request.StudentId)
            .Select(g => new GradeResponseDto(
                g.Id,
                $"{g.Student.User.FirstName} {g.Student.User.LastName}",
                g.TeacherSubject.Subject.Name,
                g.TeacherSubject.Teacher.FullName,
                g.GradeType.ToString(),
                g.Value,
                g.Date,
                g.IsPendingApproval,
                g.ChangeReason
            ))
            .ToListAsync(cancellationToken);
    }
}
