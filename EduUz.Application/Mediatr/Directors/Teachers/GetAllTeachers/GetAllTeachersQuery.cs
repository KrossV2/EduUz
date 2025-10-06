using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teachers.GetAllTeachers;

public class GetAllTeachersQuery : IRequest<IEnumerable<TeacherResponseDto>>
{
}

public class GetAllTeachersQueryHandler(ITeacherRepository repo, EduUzDbContext context)
    : IRequestHandler<GetAllTeachersQuery, IEnumerable<TeacherResponseDto>>
{
    public async Task<IEnumerable<TeacherResponseDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        var teachers = await context.Teachers
          .Include(t => t.User)
              .ThenInclude(u => u.School)
          .Include(t => t.TeacherSubjects)
              .ThenInclude(ts => ts.Subject)
          .ToListAsync(cancellationToken);

        return teachers.Select(t => new TeacherResponseDto
        {
            Id = t.Id,
            FullName = t.User.FirstName + " " + t.User.LastName,
            IsHomeroomteacher = t.IsHomeroomTeacher,
            SchoolName = t.User.School.Name,
            PhoneNumber = t.User.PhoneNumber,
            Subjects = t.TeacherSubjects.Select(s => s.Subject.Name).ToList(),
        });
    }
}
