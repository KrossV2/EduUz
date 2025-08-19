using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teachers.GetTeacherSubjects;

public class GetTeacherSubjectQuery(int id)  : IRequest<List<int>>
{
    public int Id { get; set; } = id;
}

public class GetTeacherSubjectQueryHandler(EduUzDbContext context) : IRequestHandler<GetTeacherSubjectQuery, List<int>>
{
    public async Task<List<int>> Handle(GetTeacherSubjectQuery request, CancellationToken cancellationToken)
    {
        var subjectIds = await context.TeacherSubjects
            .Where(ts => ts.TeacherId == request.Id)
            .Select(ts => ts.SubjectId)  
            .ToListAsync(cancellationToken);

        return subjectIds;
    }
}
