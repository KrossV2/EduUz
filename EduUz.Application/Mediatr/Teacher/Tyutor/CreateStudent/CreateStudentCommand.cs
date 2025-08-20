using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Tyutor.CreateStudent;

public record CreateStudentCommand(StudentCreateDto Dto) : IRequest<StudentResponseDto>;

public class CreateStudentCommandHandler(IStudentRepository repo, IUserRepository userRepo, IMapper mapper)
    : IRequestHandler<CreateStudentCommand, StudentResponseDto>
{
    public async Task<StudentResponseDto> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepo.GetByIdAsync(request.Dto.UserId);
        if (user == null) throw new Exception("User not found");

        var student = mapper.Map<Student>(request.Dto);

        await repo.AddAsync(student);
        await repo.SaveChangesAsync();

        return mapper.Map<StudentResponseDto>(student);
    }
}