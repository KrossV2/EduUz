using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Parents.GetChildGrades;

public record GetChildGradesQuery(int ChildId) : IRequest<List<GradeDto>>;

public class GetChildGradesQueryHandler : IRequestHandler<GetChildGradesQuery, List<GradeDto>>
{
    private readonly EduUzDbContext _context;

    public GetChildGradesQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<GradeDto>> Handle(GetChildGradesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Grades
            .Where(g => g.StudentId == request.ChildId)
            .Select(g => new GradeDto
            {
                Id = g.Id,
                StudentId = g.StudentId,
                TeacherSubjectId = g.TeacherSubjectId,
                GradeType = g.GradeType.ToString(),
                Value = g.Value,
                Date = g.Date,
                IsPendingApproval = g.IsPendingApproval
            })
            .ToListAsync(cancellationToken);
    }
}

