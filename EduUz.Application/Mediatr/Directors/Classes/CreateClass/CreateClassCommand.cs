using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Classes.CreateClasses;

public class CreateClassCommand(ClassCreateDto dto ) : IRequest<ClassResponseDto>
{
    public ClassCreateDto ClassCreateDto { get; set; } = dto;
}

public class CreateClassCommandHandler(IClassRepository repo, IMapper mapper) : IRequestHandler<CreateClassCommand, ClassResponseDto>
{
    public async Task<ClassResponseDto> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newClass = mapper.Map<Class>(request.ClassCreateDto);
            
            await repo.AddAsync(newClass);
            await repo.SaveChangesAsync();

            var response = mapper.Map<ClassResponseDto>(newClass);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Class", ex);
        }
    }
}

