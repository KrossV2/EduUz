using System;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.RequestGrades.GetGradesReports;

public record GetGradeReportQuery(int StudentId) : IRequest<GradeReportDto>;

public class GetGradeReportQueryHandler
    : IRequestHandler<GetGradeReportQuery, GradeReportDto>
{
    private readonly EduUzDbContext _context;

    public GetGradeReportQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<GradeReportDto> Handle(GetGradeReportQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .Include(s => s.User)
            .Include(s => s.Class)
            .Include(s => s.Grades)
                .ThenInclude(g => g.TeacherSubject)
                    .ThenInclude(ts => ts.Subject)
            .FirstOrDefaultAsync(s => s.Id == request.StudentId, cancellationToken);

        if (student == null)
            throw new KeyNotFoundException("Student not found");

        var report = new GradeReportDto
        {
            StudentId = student.Id,
            StudentName = student.User.FirstName,
            ClassId = student.ClassId ?? 0,
            ClassName = student.Class?.Name ?? "N/A"
        };

        var groupedBySubject = student.Grades
            .GroupBy(g => g.TeacherSubject.Subject)
            .ToList();

        foreach (var subjectGroup in groupedBySubject)
        {
            var subjectReport = new SubjectGradeReportDto
            {
                SubjectId = subjectGroup.Key.Id,
                SubjectName = subjectGroup.Key.Name,
                AverageGrade = subjectGroup.Average(g => g.Value),
                Grades = subjectGroup.Select(g => new GradeDetailDto
                {
                    GradeId = g.Id,
                    GradeType = g.GradeType.ToString(),
                    Value = g.Value,
                    Date = g.Date
                }).ToList()
            };

            report.Subjects.Add(subjectReport);
        }

        return report;
    }
}