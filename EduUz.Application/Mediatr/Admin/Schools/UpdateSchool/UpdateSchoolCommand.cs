using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Schools.UpdateSchool;

public class UpdateSchoolCommand(SchoolUpdateDto dto, int id) : IRequest<SchoolResponseDto>
{
    public int Id { get; set; } = id;
    public SchoolUpdateDto SchoolUpdateDto { get; set; } = dto;
}

public class UpdateSchoolCommandHandler(IMapper mapper, ISchoolRepository repo , EduUzDbContext context) : IRequestHandler<UpdateSchoolCommand, SchoolResponseDto>
{
    public async Task<SchoolResponseDto> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = await repo.GetByIdAsync(request.Id);

        if (school == null)
            throw new Exception("School Not Found!");

        mapper.Map(request.SchoolUpdateDto, school);

        repo.Update(school);
        await repo.SaveChangesAsync();

        var city = await context.Cities.FindAsync(school.CityId);
        var region = await context.Regions.FindAsync(city.RegionId);
        var director = await context.Directors.FindAsync(school.DirectorId);

        var response = new SchoolResponseDto
        {
            Id = school.Id,
            Name = school.Name,
            CityName = city.Name,
            RegionName = region.Name,
            DirectorName = director.User.FirstName + " " + director.User.LastName
        };

        return response;
    }
}
