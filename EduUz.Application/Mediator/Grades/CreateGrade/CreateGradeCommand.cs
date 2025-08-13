using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Grades.CreateGrade;

public record CreateGradeCommand(GradeCreateDto Dto) : IRequest<int>;


public class CreateGradeCommandHandler(IGradeRepository repository, IMapper mapper)
    : IRequestHandler<CreateGradeCommand, int>
{
    public async Task<int> Handle(CreateGradeCommand request, CancellationToken ct)
    {
        var grade = mapper.Map<Grade>(request.Dto);
        await repository.AddAsync(grade);
        await repository.SaveChangesAsync();
        return grade.Id;
    }
}