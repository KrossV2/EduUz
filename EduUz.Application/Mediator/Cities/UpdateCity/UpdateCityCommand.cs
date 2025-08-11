using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Cities.UpdateCity;

public class UpdateCityCommand(CityUpdateDto dto , int id) : IRequest
{
    public CityUpdateDto CityUpdateDto { get; set; } = dto;
    public int Id { get; set; } = id;
}


public class UpdateCityCommandHandler(ICityRepository repo , IMapper mapper) : IRequestHandler<UpdateCityCommand>
{
    public async Task Handle(UpdateCityCommand request, CancellationToken cancellationToken)
    {
        var city = await repo.GetByIdAsync(request.Id);

        if (city == null)
            throw new Exception("City Not Found!");

        mapper.Map(request.CityUpdateDto, city);

        repo.Update(city);
        await repo.SaveChangesAsync();
    }
}
