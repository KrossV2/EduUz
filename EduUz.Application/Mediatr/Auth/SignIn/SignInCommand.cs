    using EduUz.Application.Helpers;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Application.Services;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Auth.SignIn;

public class SignInCommand(SignInRequestDto request) : IRequest<SignInResponseDto>
{
    public SignInRequestDto Request { get; } = request;
}

public class SignInCommandHandler(
    IUserRepository userRepository,
    IAuthService authService,
    IPasswordHasher passwordHasher,
    EduUzDbContext context)
    : IRequestHandler<SignInCommand, SignInResponseDto>
{
    public async Task<SignInResponseDto> Handle(SignInCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var user = await context.Users
            .Include(u => u.Role) // 👈 Load the Role
            .FirstOrDefaultAsync(u => u.Email == request.EmailOrUsername
                                   || u.Username == request.EmailOrUsername, cancellationToken);



        if (user is null)
        {
            throw new UnauthorizedAccessException("Invalid email or password.");
        }

        var isValidPassword = passwordHasher.VerifyHash(request.Password, user.PasswordHash);
        if (!isValidPassword)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        var token = authService.GetToken(user);


        return new SignInResponseDto()
        {
            AccessToken = token,
        };
    }
}
