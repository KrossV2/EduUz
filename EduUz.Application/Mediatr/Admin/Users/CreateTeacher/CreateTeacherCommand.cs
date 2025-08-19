using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.CreateTeacher;

public class CreateTeacherCommand(TeacherCreateDto dto) : IRequest<TeacherResponseDto>
{
    public TeacherCreateDto TeacherCreateDto { get; set; } = dto;
}

public class CreateTeacherCommandHandler(ITeacherRepository repo, IMapper mapper) : IRequestHandler<CreateTeacherCommand, TeacherResponseDto>
{
    public async Task<TeacherResponseDto> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var teacher = mapper.Map<Teacher>(request.TeacherCreateDto);

            await repo.AddAsync(teacher);
            await repo.SaveChangesAsync();

            var response = mapper.Map<TeacherResponseDto>(teacher);

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
