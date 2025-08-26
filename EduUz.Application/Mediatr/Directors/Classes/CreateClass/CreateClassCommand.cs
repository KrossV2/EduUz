using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Classes.CreateClasses;

public class CreateClassCommand(ClassCreateDto dto ) : IRequest<ClassResponseDto>
{
    public ClassCreateDto ClassCreateDto { get; set; } = dto;
}

public class CreateClassCommandHandler(IClassRepository repo, IMapper mapper  , EduUzDbContext context) : IRequestHandler<CreateClassCommand, ClassResponseDto>
{
    public async Task<ClassResponseDto> Handle(CreateClassCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newClass = mapper.Map<Class>(request.ClassCreateDto);
            
            await repo.AddAsync(newClass);
            await repo.SaveChangesAsync();

            var school = await context.Schools.FindAsync(newClass.SchoolId);
            var teacher = await context.Teachers
                .Include(t => t.User) // User ham yuklansin
                .FirstOrDefaultAsync(t => t.Id == newClass.HomeroomTeacherId);

            var studentCount = await context.Students
                .CountAsync(s => s.ClassId == newClass.Id, cancellationToken); // Faqat shu classga tegishli studentlar

            var response = new ClassResponseDto
            {
                Id = newClass.Id,
                Name = newClass.Name,
                Shift = newClass.Shift.ToString(),
                SchoolName = school?.Name ?? "Unknown",  // null check
                HomeroomTeacherName = teacher != null
                    ? teacher.User.FirstName + " " + teacher.User.LastName
                    : "No homeroom teacher",
                StudentCount = studentCount
            };


            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Class", ex);
        }
    }
}

