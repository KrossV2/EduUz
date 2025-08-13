using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Parents.LinkParentStudent;

public class LinkParentStudentCommand(ParentStudentCreateDto dto) : IRequest<ParentStudentDto>
{
    public ParentStudentCreateDto ParentStudentCreateDto { get; set; } = dto;
}

public class LinkParentStudentCommandHandler(IParentStudentRepository repo, IMapper mapper) : IRequestHandler<LinkParentStudentCommand, ParentStudentDto>
{
    public async Task<ParentStudentDto> Handle(LinkParentStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newLink = mapper.Map<ParentStudent>(request.ParentStudentCreateDto);
            
            await repo.AddAsync(newLink);
            await repo.SaveChangesAsync();

            var response = mapper.Map<ParentStudentDto>(newLink);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error linking parent to student", ex);
        }
    }
}