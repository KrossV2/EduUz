using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Homeworks.UpdateHomework;

public class UpdateHomeworkCommand(int id, HomeworkUpdateDto dto) : IRequest<HomeworkResponseDto>
{
    public int Id { get; set; } = id;
    public HomeworkUpdateDto HomeworkUpdateDto { get; set; } = dto;
}

public class UpdateHomeworkCommandHandler(IHomeworkRepository repo, IMapper mapper) : IRequestHandler<UpdateHomeworkCommand, HomeworkResponseDto>
{
    public async Task<HomeworkResponseDto> Handle(UpdateHomeworkCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingHomework = await repo.GetByIdAsync(request.Id);
            if (existingHomework == null)
            {
                throw new ApplicationException("Homework not found");
            }

            mapper.Map(request.HomeworkUpdateDto, existingHomework);
            
            repo.Update(existingHomework);
            await repo.SaveChangesAsync();

            var response = mapper.Map<HomeworkResponseDto>(existingHomework);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error updating homework", ex);
        }
    }
}