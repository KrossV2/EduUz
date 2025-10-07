using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Admin.Schools.UpdateSchool;

public class UpdateSchoolCommand(SchoolUpdateDto dto, int id) : IRequest<SchoolResponseDto>
{
    public int Id { get; set; } = id;
    public SchoolUpdateDto SchoolUpdateDto { get; set; } = dto;
}

public class UpdateSchoolCommandHandler(IMapper mapper, ISchoolRepository repo, EduUzDbContext context)
    : IRequestHandler<UpdateSchoolCommand, SchoolResponseDto>
{
    public async Task<SchoolResponseDto> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = await repo.GetByIdAsync(request.Id);

        if (school == null)
            throw new ApplicationException("School not found!");

        // Ma'lumotni yangilash
        mapper.Map(request.SchoolUpdateDto, school);
        repo.Update(school);
        await repo.SaveChangesAsync();

        // Bog‘liq ma'lumotlarni yuklash
        var city = await context.Cities.FindAsync(school.CityId);
        if (city == null)
            throw new ApplicationException($"City with ID {school.CityId} not found");

        var region = await context.Regions.FindAsync(city.RegionId);
        if (region == null)
            throw new ApplicationException($"Region with ID {city.RegionId} not found");

        var director = await context.Directors
            .Include(d => d.User)
            .FirstOrDefaultAsync(d => d.Id == school.DirectorId, cancellationToken);

        if (director == null)
            throw new ApplicationException($"Director with ID {school.DirectorId} not found");

        if (director.User == null)
            throw new ApplicationException("Director has no linked user");

        // Response
        var response = new SchoolResponseDto
        {
            Id = school.Id,
            Name = school.Name,
            CityName = city.Name,
            RegionName = region.Name,
            DirectorName = $"{director.User.FirstName} {director.User.LastName}"
        };

        return response;
    }
}

