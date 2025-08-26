using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.Classes.GetAllClasses;

public class GetAllClassesQuery : IRequest<IEnumerable<ClassResponseDto>>
{
}

public class GetAllClassesQueryHandler(IClassRepository repo , EduUzDbContext  context) : IRequestHandler<GetAllClassesQuery, IEnumerable<ClassResponseDto>>
{
    public async Task<IEnumerable<ClassResponseDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        // Eager loading kerak (School, Teacher, Student)
        var classes = await context.Set<Class>()
            .Include(c => c.School)
            .Include(c => c.HomeroomTeacher)
                .ThenInclude(t => t.User)
            .Include(c => c.Students)
            .ToListAsync(cancellationToken);

        // DTOga maplash
        var response = classes.Select(c => new ClassResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            Shift = c.Shift.ToString(),
            SchoolName = c.School?.Name,
            HomeroomTeacherName = c.HomeroomTeacher != null
                ? c.HomeroomTeacher.User.FirstName + " " + c.HomeroomTeacher.User.LastName
                : "No teacher assigned",
            StudentCount = c.Students?.Count ?? 0
        });

        return response;
    }
}
