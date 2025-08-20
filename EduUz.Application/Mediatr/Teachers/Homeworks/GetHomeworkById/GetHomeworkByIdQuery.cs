using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.Homeworks.GetHomeworkById;


public record GetHomeworkByIdQuery(int Id) : IRequest<HomeworkResponseDto>;

public class GetHomeworkByIdQueryHandler(IHomeworkRepository repo, IMapper mapper)
    : IRequestHandler<GetHomeworkByIdQuery, HomeworkResponseDto>
{
    public async Task<HomeworkResponseDto> Handle(GetHomeworkByIdQuery request, CancellationToken cancellationToken)
    {
        var homework = await repo.GetByIdAsync(request.Id);

        if (homework == null)
            throw new Exception("Homework not found");

        return mapper.Map<HomeworkResponseDto>(homework);
    }
}