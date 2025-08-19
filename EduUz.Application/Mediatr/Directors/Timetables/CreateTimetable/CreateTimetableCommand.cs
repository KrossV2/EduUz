using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Timetables.CreateTimetable;

public class CreateTimetableCommand(TimetableCreateDto dto) : IRequest<TimetableResponseDto>
{
    public TimetableCreateDto TimetableCreateDto { get; set; } = dto;
}

public class CreateTimetableCommandHandler(ITimetableRepository repo, IMapper mapper) : IRequestHandler<CreateTimetableCommand, TimetableResponseDto>
{
    public async Task<TimetableResponseDto> Handle(CreateTimetableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var table = mapper.Map<Timetable>(request.TimetableCreateDto);

            await repo.AddAsync(table);
            await repo.SaveChangesAsync();

            var response = mapper.Map<TimetableResponseDto>(table);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Timetable", ex);
        }
    }
}
