using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Tyutor.CreateParent;

public record CreateParentCommand(int UserId) : IRequest<int>; 

public class CreateParentCommandHandler(IParentRepository repo, IUserRepository userRepo, IMapper mapper)
    : IRequestHandler<CreateParentCommand, int>
{
    public async Task<int> Handle(CreateParentCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByIdAsync(request.UserId);
        if (user == null) throw new Exception("User not found");

        var parent = new Parent { UserId = request.UserId };

        await repo.AddAsync(parent);
        await repo.SaveChangesAsync();

        return parent.Id;
    }
}