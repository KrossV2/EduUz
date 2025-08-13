using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Grades.GradeFilter;

public record GetFilteredGradesQuery(GradeFilterDto Filter) : IRequest<List<GradeResponseDto>>;


public class GetFilteredGradesQueryHandler(IGradeRepository repository, IMapper mapper)
    : IRequestHandler<GetFilteredGradesQuery, List<GradeResponseDto>>
{
    public async Task<List<GradeResponseDto>> Handle(GetFilteredGradesQuery request, CancellationToken ct)
    {
        var grades = await repository.GetFilteredGradesAsync(request.Filter);
        return mapper.Map<List<GradeResponseDto>>(grades);
    }
}
