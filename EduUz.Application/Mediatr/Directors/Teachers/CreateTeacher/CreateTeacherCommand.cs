using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Application.Services;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.Teachers.CreateTeacher;

public class CreateTeacherCommand(TeacherCreateDto dto) : IRequest<TeacherResponseDto>
{
    public TeacherCreateDto TeacherCreateDto { get; set; } = dto;
}

public class CreateTeacherCommandHandler(ITeacherRepository repo, IMapper mapper, EduUzDbContext context , IFileService  fileService) : IRequestHandler<CreateTeacherCommand, TeacherResponseDto>
{
    public async Task<TeacherResponseDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var teacher = mapper.Map<Teacher>(request.TeacherCreateDto);
            
            var user = await context.Users.FindAsync(teacher.UserId);

            if (request.TeacherCreateDto.Image != null)
            {
                user.ImagePath = await fileService.SaveFileAsync(request.TeacherCreateDto.Image, "users");
            }

            var school = await context.Schools.FindAsync(user.SchoolId);

            var teacherWithAllData = await context.Teachers
    .Include(t => t.User)
        .ThenInclude(u => u.School)
    .Include(t => t.TeacherSubjects)
        .ThenInclude(ts => ts.Subject)
    .FirstOrDefaultAsync(t => t.Id == teacher.Id, cancellationToken);

            await repo.AddAsync(teacher);
            await repo.SaveChangesAsync();

            if (school == null)
                throw new Exception();

            var response = new TeacherResponseDto
            {
                Id = teacher.Id,
                FullName = teacher.User.FirstName + " " + teacher.User.LastName,
                IsHomeroomteacher = teacher.IsHomeroomTeacher,
                SchoolName = school.Name,
                PhoneNumber = user.PhoneNumber,
                Subjects = teacherWithAllData.TeacherSubjects
                .Select(ts => ts.Subject.Name)
                .ToList()
            };

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Teacher", ex);
        }
    }
}
