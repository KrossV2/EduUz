using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Students.GetMyTimetable;

public class GetMyTimetableQuery(int studentId) : IRequest<List<Timetable>>
{
    public int StudentId { get; set; } = studentId;
}

public class GetMyTimetableQueryHandler(ITimetableRepository timetableRepo, IStudentRepository studentRepo) : IRequestHandler<GetMyTimetableQuery, List<Timetable>>
{
    public async Task<List<Timetable>> Handle(GetMyTimetableQuery request, CancellationToken cancellationToken)
    {
        // First get the student's class
        var student = studentRepo.GetAll()
            .FirstOrDefault(s => s.Id == request.StudentId);
        
        if (student?.ClassId == null)
        {
            return new List<Timetable>();
        }

        // Get timetables for the student's class
        var timetables = timetableRepo.GetAll()
            .Where(t => t.LessonSchedule.ClassId == student.ClassId)
            .OrderBy(t => t.LessonSchedule.DayOfWeek)
            .ThenBy(t => t.LessonSchedule.LessonNumber)
            .ToList();
        
        return timetables;
    }
}