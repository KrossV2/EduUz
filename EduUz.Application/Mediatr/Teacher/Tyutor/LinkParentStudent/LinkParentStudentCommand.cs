
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Tyutor.LinkParentStudent;

public record LinkParentStudentCommand(int ParentId, int StudentId) : IRequest;

public class LinkParentStudentCommandHandler(IParentStudentRepository repo, IParentRepository parentRepo, IStudentRepository studentRepo)
    : IRequestHandler<LinkParentStudentCommand>
{
    public async Task Handle(LinkParentStudentCommand request, CancellationToken cancellationToken)
    {
        var parent = await parentRepo.GetByIdAsync(request.ParentId);
        if (parent == null) throw new Exception("Parent not found");

        var student = await studentRepo.GetByIdAsync(request.StudentId);
        if (student == null) throw new Exception("Student not found");

        var link = new ParentStudent
        {
            ParentId = request.ParentId,
            StudentId = request.StudentId
        };

        await repo.AddAsync(link);
        await repo.SaveChangesAsync();
    }
}