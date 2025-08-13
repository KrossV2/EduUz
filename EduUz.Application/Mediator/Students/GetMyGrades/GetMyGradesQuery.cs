using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Students.GetMyGrades;

public class GetMyGradesQuery(int studentId) : IRequest<List<Grade>>
{
    public int StudentId { get; set; } = studentId;
}

public class GetMyGradesQueryHandler(IGradeRepository repo) : IRequestHandler<GetMyGradesQuery, List<Grade>>
{
    public async Task<List<Grade>> Handle(GetMyGradesQuery request, CancellationToken cancellationToken)
    {
        var grades = repo.GetAll()
            .Where(g => g.StudentId == request.StudentId)
            .OrderByDescending(g => g.Date)
            .ToList();
        
        return grades;
    }
}