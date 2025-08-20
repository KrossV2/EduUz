using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Students.SubmitHomework;

// Command
public record SubmitHomeworkCommand(int HomeworkId, int StudentId, string FileUrl, string Comment) : IRequest<bool>;

// Handler
public class SubmitHomeworkCommandHandler : IRequestHandler<SubmitHomeworkCommand, bool>
{
    private readonly EduUzDbContext _context;

    public SubmitHomeworkCommandHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(SubmitHomeworkCommand request, CancellationToken cancellationToken)
    {
        var submission = new HomeworkSubmission
        {
            HomeworkId = request.HomeworkId,
            StudentId = request.StudentId,
            FileUrl = request.FileUrl,
            Comment = request.Comment,
            SubmittedAt = DateTime.UtcNow
        };

        _context.HomeworkSubmissions.Add(submission);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
