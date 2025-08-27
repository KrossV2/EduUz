using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Timetables.GetAllTimetable;

public class GetAllTimetablesQuery : IRequest<IEnumerable<TimetableResponseDto>>
{
}

public class GetAllTimetablesQueryHandler(EduUzDbContext context, IMapper mapper)
    : IRequestHandler<GetAllTimetablesQuery, IEnumerable<TimetableResponseDto>>
{
    public async Task<IEnumerable<TimetableResponseDto>> Handle(GetAllTimetablesQuery request, CancellationToken cancellationToken)
    {
        var timetables = await context.Timetables
            .Include(t => t.LessonSchedule)
                .ThenInclude(ls => ls.Class)
            .Include(t => t.LessonSchedule)
                .ThenInclude(ls => ls.TeacherSubject)
                    .ThenInclude(ts => ts.Subject)
            .Include(t => t.LessonSchedule)
                .ThenInclude(ls => ls.TeacherSubject)
                    .ThenInclude(ts => ts.Teacher)
                        .ThenInclude(u => u.User)
            .ToListAsync(cancellationToken);

        var response = timetables.Select(table => new TimetableResponseDto
        {
            Id = table.Id,
            ClassName = table.LessonSchedule.Class.Name,
            SubjectName = table.LessonSchedule.TeacherSubject.Subject.Name,
            TeacherName = table.LessonSchedule.TeacherSubject.Teacher.User.FirstName + " " +
                          table.LessonSchedule.TeacherSubject.Teacher.User.LastName,
            DayOfWeek = table.LessonSchedule.DayOfWeek.ToString(),
            LessonNumber = table.LessonSchedule.LessonNumber,
            StartTime = table.StartTime.ToString(@"hh\:mm"),
            EndTime = table.EndTime.ToString(@"hh\:mm")
        });

        return response;
    }
}