using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Parents.CreateParent;

public class CreateParentCommand(ParentCreateDto dto) : IRequest<ParentResponseDto>
{
    public ParentCreateDto ParentCreateDto { get; set; } = dto;
}

public class CreateParentCommandHandler(IParentRepository repo, IMapper mapper) : IRequestHandler<CreateParentCommand, ParentResponseDto>
{
    public async Task<ParentResponseDto> Handle(CreateParentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newParent = mapper.Map<Parent>(request.ParentCreateDto);
            
            await repo.AddAsync(newParent);
            await repo.SaveChangesAsync();

            var response = mapper.Map<ParentResponseDto>(newParent);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating parent", ex);
        }
    }
}