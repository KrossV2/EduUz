using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Directors.CreateDirector;

public class CreateDirectorCommand(DirectorCreateDto dto) : IRequest<int>
{
    public DirectorCreateDto DirectorCreateDto { get; set; } = dto;
}

public class CreateDirectorCommandHandler(IDirectorRepository repo, IMapper mapper) : IRequestHandler<CreateDirectorCommand, int>
{
    public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var director = mapper.Map<Director>(request.DirectorCreateDto);

            await repo.AddAsync(director);
            await repo.SaveChangesAsync();

            return director.Id;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Director", ex);
        }
    }
}
