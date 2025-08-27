using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Timetables.CreateTimetable;

public class CreateTimetableCommand(TimetableCreateDto dto) : IRequest<TimetableResponseDto>
{
    public TimetableCreateDto TimetableCreateDto { get; set; } = dto;
}

public class CreateTimetableCommandHandler(ITimetableRepository repo, IMapper mapper , EduUzDbContext context) : IRequestHandler<CreateTimetableCommand, TimetableResponseDto>
{
    public async Task<TimetableResponseDto> Handle(CreateTimetableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var table = mapper.Map<Timetable>(request.TimetableCreateDto);

            await repo.AddAsync(table);
            await repo.SaveChangesAsync();

            var response = new TimetableResponseDto
            {
                Id = table.Id,
                ClassName = table.LessonSchedule.Class.Name,
                SubjectName = table.LessonSchedule.TeacherSubject.Subject.Name,
                TeacherName = table.LessonSchedule.TeacherSubject.Teacher.User.FirstName + "  " + table.LessonSchedule.TeacherSubject.Teacher.User.LastName,
                DayOfWeek = table.LessonSchedule.DayOfWeek.ToString(),
                LessonNumber = table.LessonSchedule.LessonNumber,
                StartTime = table.StartTime.ToString(),
                EndTime = table.EndTime.ToString()
            };

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
