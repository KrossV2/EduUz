using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Timetables.UpdateTimetable;

public class UpdateTimetableCommand(TimetableUpdateDto dto , int id) : IRequest<TimetableResponseDto>
{
    public int Id { get; set; } = id;
    public TimetableUpdateDto dto { get; set; } = dto;
}


public class UpdateTimetableCommandHandler(ITimetableRepository repo, IMapper mapper) : IRequestHandler<UpdateTimetableCommand, TimetableResponseDto>
{
    public async Task<TimetableResponseDto> Handle(UpdateTimetableCommand request, CancellationToken cancellationToken)
    {
        var timetable = await repo.GetByIdAsync(request.Id);

        if (timetable == null)
            throw new Exception("Subject Not Found!");

        mapper.Map(request.dto, timetable);

        repo.Update(timetable);
        await repo.SaveChangesAsync();

        return mapper.Map<TimetableResponseDto>(timetable);
    }
}
