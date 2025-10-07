using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Admin.Directors.GetAllDirectors;

public class GetAllDirectorsQuery : IRequest<List<DirectorResponseDto>>;

public class GetAllDirectorsQueryHandler(EduUzDbContext context)
    : IRequestHandler<GetAllDirectorsQuery, List<DirectorResponseDto>>
{
    public async Task<List<DirectorResponseDto>> Handle(GetAllDirectorsQuery request, CancellationToken cancellationToken)
    {
        var directors = await context.Directors
            .Include(d => d.User)
            .Include(d => d.School)
            .Select(d => new DirectorResponseDto
            {
                Id = d.Id,
                UserId = d.UserId,
                FirstName = d.User.FirstName,
                LastName = d.User.LastName,
                Email = d.User.Email,
                PhoneNumber = d.User.PhoneNumber,
                Username = d.User.Username,
                SchoolId = d.SchoolId,
                ImagePath = d.User.ImagePath,
                SchoolName = d.School.Name
            })
            .ToListAsync(cancellationToken);

        return directors;
    }
}
