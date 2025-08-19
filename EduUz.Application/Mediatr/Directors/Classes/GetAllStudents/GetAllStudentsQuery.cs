using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Director.Classes.GetAllStudents;

public class GetAllStudentsQuery(int id) : IRequest<IEnumerable<Student>>
{
    public int Id { get; set; } = id;
}

public class GetAllStudentsQueryHandler(EduUzDbContext context) : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
{
    public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
    {
        var students = await context.Students         
            .Where(s => s.ClassId == request.Id) 
            .ToListAsync(cancellationToken);

        return students;
    }
}
