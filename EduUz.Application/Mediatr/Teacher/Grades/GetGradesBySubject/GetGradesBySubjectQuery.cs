using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teacher.Grades.GetGradesBySubject;

public record GetGradesBySubjectQuery(int SubjectId) : IRequest<List<GradeResponseDto>>;

public class GetGradesBySubjectQueryHandler(EduUzDbContext context)
    : IRequestHandler<GetGradesBySubjectQuery, List<GradeResponseDto>>
{
    public async Task<List<GradeResponseDto>> Handle(GetGradesBySubjectQuery request, CancellationToken cancellationToken)
    {
        return await context.Grades
            .Include(g => g.Student).ThenInclude(s => s.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Teacher).ThenInclude(t => t.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Subject)
            .Where(g => g.TeacherSubject.SubjectId == request.SubjectId)
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
