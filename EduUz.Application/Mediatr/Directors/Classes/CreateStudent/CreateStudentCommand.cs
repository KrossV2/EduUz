using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Sutudents.CreateStudent;

public class CreateStudentCommand (StudentCreateDto dto) : IRequest<StudentResponseDto>
{
    public StudentCreateDto StudentCreateDto { get; set; } = dto;
}

public class CreateStudentCommandHandler(IStudentRepository repo, IMapper mapper) : IRequestHandler<CreateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var student = mapper.Map<Student>(request.StudentCreateDto);

            await repo.AddAsync(student);
            await repo.SaveChangesAsync();

            var response = mapper.Map<StudentResponseDto>(student);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Student", ex);
        }
    }
}
