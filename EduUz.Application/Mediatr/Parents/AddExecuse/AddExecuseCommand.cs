using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using System;

namespace EduUz.Application.Mediatr.Parents.AddExecuse;


public record AddExcuseCommand(int ChildId, string Reason, DateTime Date) : IRequest<bool>;

public class AddExcuseCommandHandler : IRequestHandler<AddExcuseCommand, bool>
{
    private readonly EduUzDbContext _context;

    public AddExcuseCommandHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(AddExcuseCommand request, CancellationToken cancellationToken)
    {
        var excuse = new Excuse
        {
            StudentId = request.ChildId,
            Reason = request.Reason,
            Date = request.Date
        };

        _context.Excuses.Add(excuse);
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
