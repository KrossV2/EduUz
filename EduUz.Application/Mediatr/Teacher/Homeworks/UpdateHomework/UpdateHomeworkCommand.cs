using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Homeworks.UpdateHomework;
public record UpdateHomeworkCommand(HomeworkUpdateDto dto , int id) : IRequest<HomeworkResponseDto>;

public class UpdateHomeworkCommandHandler(IHomeworkRepository repo, IMapper mapper) : IRequestHandler<UpdateHomeworkCommand, HomeworkResponseDto>
{
    public async Task<HomeworkResponseDto> Handle(UpdateHomeworkCommand request, CancellationToken cancellationToken)
    {
        var homework = await repo.GetByIdAsync(request.id);

        if (homework == null)
            throw new Exception("homework Not Found!");

        mapper.Map(request.dto, homework);

        repo.Update(homework);
        await repo.SaveChangesAsync();

        return mapper.Map<HomeworkResponseDto>(homework);
    }
}
