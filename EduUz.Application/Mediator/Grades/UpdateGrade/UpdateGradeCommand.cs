using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Grades.UpdateGrade;

public record UpdateGradeCommand(int Id, GradeUpdateDto Dto) : IRequest<Unit>;



public class UpdateGradeCommandHandler(IGradeRepository repository)
    : IRequestHandler<UpdateGradeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateGradeCommand request, CancellationToken ct)
    {
        var grade = await repository.GetByIdAsync(request.Id);
        if (grade == null) throw new Exception("Grade topilmadi");

        if (request.Dto.Value.HasValue)
            grade.Value = request.Dto.Value.Value;

        if (!string.IsNullOrEmpty(request.Dto.ChangeReason))
            grade.ChangeReason = request.Dto.ChangeReason;

        repository.Update(grade);
        await repository.SaveChangesAsync();
        return Unit.Value;
    }
}
