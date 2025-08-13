using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Homeworks.CreateHomework;

public class CreateHomeworkCommand(HomeworkCreateDto dto) : IRequest<HomeworkResponseDto>
{
    public HomeworkCreateDto HomeworkCreateDto { get; set; } = dto;
}

public class CreateHomeworkCommandHandler(IHomeworkRepository repo, IMapper mapper) : IRequestHandler<CreateHomeworkCommand, HomeworkResponseDto>
{
    public async Task<HomeworkResponseDto> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newHomework = mapper.Map<Homework>(request.HomeworkCreateDto);
            
            await repo.AddAsync(newHomework);
            await repo.SaveChangesAsync();

            var response = mapper.Map<HomeworkResponseDto>(newHomework);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating homework", ex);
        }
    }
}