using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Application.Services;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Users.UpdateUser;

public class UpdateUserCommand(UserUpdateDto dto  , int id) :  IRequest<UserResponseDto>
{
    public int Id { get; set; } = id;
    public UserUpdateDto UserUpdateDto { get; set; } = dto;
}

public class UpdateUserCommandHanler(IUserRepository repo, IMapper mapper , EduUzDbContext context , IFileService fileService) : IRequestHandler<UpdateUserCommand, UserResponseDto>
{
    public async Task<UserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repo.GetByIdAsync(request.Id);

        if (user == null)
            throw new Exception("User Not Found!");

        if (request.UserUpdateDto.Image != null && request.UserUpdateDto.Image.Length > 0)
        {
            if (!string.IsNullOrEmpty(user.ImagePath))
            {
                fileService.DeleteFile(user.ImagePath);
            }

            var savedPath = await fileService.SaveFileAsync(request.UserUpdateDto.Image, "users");
            user.ImagePath = savedPath;
        }

        mapper.Map(request.UserUpdateDto, user);

        repo.Update(user);
        await repo.SaveChangesAsync();

        var rolename = await context.Roles.FindAsync(user.RoleId);
        var school = await context.Schools.FindAsync(user.SchoolId);

        var response = new UserResponseDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email =  user.Email,
            PhoneNumber =  user.PhoneNumber,
            Username = user.Username,
            RoleName = rolename.Name,
            SchoolName = school.Name
        };

        return response;
    }
}
