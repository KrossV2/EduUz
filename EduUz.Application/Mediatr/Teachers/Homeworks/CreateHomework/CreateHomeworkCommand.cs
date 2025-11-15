using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teachers.Homeworks.CreateHomework;

public record CreateHomeworkCommand(HomeworkCreateDto dto) : IRequest<HomeworkResponseDto>;


public class CreateHomeworkCommandHandler(IHomeworkRepository repo, IMapper mapper , EduUzDbContext context) : IRequestHandler<CreateHomeworkCommand, HomeworkResponseDto>
{
    public async Task<HomeworkResponseDto> Handle(CreateHomeworkCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var homework = mapper.Map<Homework>(request.dto);

            await repo.AddAsync(homework);
            await repo.SaveChangesAsync();

            var students = await context.Students
           .Where(s => s.ClassId == homework.ClassId)
           .ToListAsync(cancellationToken);

            foreach (var student in students)
            {
                student.Homework.Add(homework);
            }

            await context.SaveChangesAsync(cancellationToken);

            var response = mapper.Map<HomeworkResponseDto>(homework);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating homework", ex);
        }
    }
}
