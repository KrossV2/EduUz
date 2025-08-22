using AutoMapper;
using EduUz.Application.Helpers;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Auth.SignUp;
public class SignUpCommand(UserCreateDto request) : IRequest<UserResponseDto>
{
    public UserCreateDto Request { get; } = request;
}

public class SignUpCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, EduUzDbContext context , IMapper mappper) : IRequestHandler<SignUpCommand, UserResponseDto>
{
    public async Task<UserResponseDto> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var  user = mappper.Map<User>(command.Request);

        await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();

        var role = await context.Roles.FindAsync(user.RoleId);
        var school = user.SchoolId.HasValue
            ? await context.Schools.FindAsync(user.SchoolId.Value)
            : null;

        return new UserResponseDto(
            Id: user.Id,
            FirstName: user.FirstName,
            LastName: user.LastName,
            Email: user.Email,
            Username: user.Username,
            RoleName: role?.Name ?? "Unknown",
            SchoolName: school?.Name ?? "Not Assigned"
        );
    }
}
