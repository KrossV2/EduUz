using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Users.UpdateUser;

public class UpdateUserCommand(UserUpdateDto dto  , int id) :  IRequest<UserResponseDto>
{
    public int Id { get; set; } = id;
    public UserUpdateDto UserUpdateDto { get; set; } = dto;
}

public class UpdateUserCommandHanler(IUserRepository repo, IMapper mapper) : IRequestHandler<UpdateUserCommand, UserResponseDto>
{
    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repo.GetByIdAsync(request.Id);

        if (user == null)
            throw new Exception("User Not Found!");

        mapper.Map(request.UserUpdateDto, user);

        repo.Update(user);
        await repo.SaveChangesAsync();

        return mapper.Map<UserResponseDto>(user);
    }
}
