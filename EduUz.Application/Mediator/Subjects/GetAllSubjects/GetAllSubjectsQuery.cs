using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Subjects.GetAllSubjects;

public class GetAllSubjectsQuery :  IRequest<IEnumerable<Subject>>
{
}


public class GetAllSubjectsQueryHandler(ISubjectRepository repo) : IRequestHandler<GetAllSubjectsQuery, IEnumerable<Subject>>
{
    public async Task<IEnumerable<Subject>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
