using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Homeworks.UploadHomeworkMaterial;

public record UploadHomeworkMaterialCommand(int HomeworkId, string FilePath) : IRequest;

public class UploadHomeworkMaterialCommandHandler(IHomeworkRepository repo)
    : IRequestHandler<UploadHomeworkMaterialCommand>
{
    public async Task Handle(UploadHomeworkMaterialCommand request, CancellationToken cancellationToken)
    {
        var homework = await repo.GetByIdAsync(request.HomeworkId);

        if (homework == null)
            throw new Exception("Homework not found");

        homework.AttachmentPath = request.FilePath;

        repo.Update(homework);
        await repo.SaveChangesAsync();
    }
}