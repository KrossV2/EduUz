using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Students.GetAllTimetables;

public class GetAllTimetablesQuery : IRequest<IEnumerable<Timetable>>;


public class GetAllTimetablesQueryHandler(ITimetableRepository repo) : IRequestHandler<GetAllTimetablesQuery, IEnumerable<Timetable>>
{
    public async Task<IEnumerable<Timetable>> Handle(GetAllTimetablesQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
