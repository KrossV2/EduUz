using System;
using System.Linq;
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

public class SignUpCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, EduUzDbContext context) : IRequestHandler<SignUpCommand, UserResponseDto>
{
    public async Task<UserResponseDto> Handle(SignUpCommand command, CancellationToken cancellationToken)
    {
        var request  = command.Request;

        // Validate unique email and username
        var existingUser = context.Users.FirstOrDefault(u => u.Email == request.Email || u.Username == request.Username);
        if (existingUser != null)
        {
            if (existingUser.Email == request.Email)
                throw new InvalidOperationException("Email already exists");
            if (existingUser.Username == request.Username)
                throw new InvalidOperationException("Username already exists");
        }

        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Username = request.Username,
            PasswordHash = passwordHasher.HashPassword(request.Password),
            RoleId = request.RoleId,
            SchoolId = request.SchoolId > 0 ? request.SchoolId : null
        };

        await userRepository.AddAsync(user);
        await userRepository.SaveChangesAsync();

        // Create role-specific entity based on RoleId
        await CreateRoleSpecificEntity(user);
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

    private async Task CreateRoleSpecificEntity(User user)
    {
        switch (user.RoleId)
        {
            case 1: // Admin - no specific entity needed
                break;
            case 2: // Director
                var director = new Director
                {
                    UserId = user.Id,
                    SchoolId = user.SchoolId ?? throw new InvalidOperationException("Director must have a school assigned")
                };
                await context.Directors.AddAsync(director);
                break;
            case 3: // Teacher
                var teacher = new Teacher
                {
                    UserId = user.Id,
                    IsHomeroomTeacher = false
                };
                await context.Teachers.AddAsync(teacher);
                break;
            case 4: // Student
                var student = new Student
                {
                    UserId = user.Id,
                    ClassId = null // Will be assigned later
                };
                await context.Students.AddAsync(student);
                break;
            case 5: // Parent
                var parent = new Parent
                {
                    UserId = user.Id
                };
                await context.Parents.AddAsync(parent);
                break;
            default:
                throw new ArgumentException($"Invalid role ID: {user.RoleId}");
        }
    }
}
