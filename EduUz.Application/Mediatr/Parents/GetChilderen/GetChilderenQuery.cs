using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Parents.GetChildren;

public record GetChildrenQuery(int ParentId) : IRequest<List<StudentDto>>;

public class GetChildrenQueryHandler : IRequestHandler<GetChildrenQuery, List<StudentDto>>
{
    private readonly EduUzDbContext _context;

    public GetChildrenQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<StudentDto>> Handle(GetChildrenQuery request, CancellationToken cancellationToken)
    {
        var students = await _context.ParentStudents
            .Where(ps => ps.ParentId == request.ParentId)
            .Select(ps => new StudentDto(
                ps.Student.Id,
                ps.Student.UserId,
                ps.Student.User.FirstName + " " + ps.Student.User.LastName,
                ps.Student.Class.Name
            ))
            .ToListAsync(cancellationToken);

        return students;
    }
}
