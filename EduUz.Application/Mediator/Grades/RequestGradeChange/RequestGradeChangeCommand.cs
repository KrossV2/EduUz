using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Grades.RequestGradeChange;


public record RequestGradeChangeCommand(GradeChangeRequestDto Dto) : IRequest<Unit>;


public class RequestGradeChangeCommandHandler(IGradeRepository repository)
    : IRequestHandler<RequestGradeChangeCommand, Unit>
{
    public async Task<Unit> Handle(RequestGradeChangeCommand request, CancellationToken ct)
    {
        var grade = await repository.GetByIdAsync(request.Dto.GradeId);
        if (grade == null) throw new Exception("Grade topilmadi");

        grade.IsPendingApproval = true;
        grade.ChangeReason = request.Dto.Reason;
        grade.OriginalGradeId = grade.Id; // Original baho saqlanadi

        repository.Update(grade);
        await repository.SaveChangesAsync();
        return Unit.Value;
    }
}