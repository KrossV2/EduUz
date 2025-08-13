using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Homeworks.GetAllHomeworks;

public class GetAllHomeworksQuery : IRequest<List<Homework>>
{
    public int? TeacherId { get; set; }
    public int? ClassId { get; set; }
    public int? SubjectId { get; set; }
}

public class GetAllHomeworksQueryHandler(IHomeworkRepository repo) : IRequestHandler<GetAllHomeworksQuery, List<Homework>>
{
    public async Task<List<Homework>> Handle(GetAllHomeworksQuery request, CancellationToken cancellationToken)
    {
        var query = repo.GetAll().AsQueryable();

        if (request.TeacherId.HasValue)
        {
            query = query.Where(h => h.TeacherSubject.TeacherId == request.TeacherId.Value);
        }

        if (request.ClassId.HasValue)
        {
            query = query.Where(h => h.ClassId == request.ClassId.Value);
        }

        if (request.SubjectId.HasValue)
        {
            query = query.Where(h => h.TeacherSubject.SubjectId == request.SubjectId.Value);
        }

        return query.ToList();
    }
}