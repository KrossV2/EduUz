using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Students.GetAllGrades;

public class GetAllGradesQuery : IRequest<IEnumerable<Grade>>;


public class GetAllGradesQueryHandler(IGradeRepository repo) : IRequestHandler<GetAllGradesQuery, IEnumerable<Grade>>
{
    public async Task<IEnumerable<Grade>> Handle(GetAllGradesQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
