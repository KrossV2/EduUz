using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Cities.CreateCity;

public class CreateCityCommand(CityCreateDto dto) : IRequest<CityResponseDto>
{
    public CityCreateDto CityCreateDto { get; set; } = dto;
}


public class CreateCityCommandHandler(ICityRepository repo, IMapper mapper , EduUzDbContext context) : IRequestHandler<CreateCityCommand, CityResponseDto>
{
    public async Task<CityResponseDto> Handle(CreateCityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newCity = mapper.Map<City>(request.CityCreateDto);

            var region = await context.Regions.FindAsync(newCity.RegionId);

            await repo.AddAsync(newCity);
            await repo.SaveChangesAsync();

            var response = mapper.Map<CityResponseDto>(newCity);
            response.RegionName = region.Name;

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating city", ex);
        }
    }
}
