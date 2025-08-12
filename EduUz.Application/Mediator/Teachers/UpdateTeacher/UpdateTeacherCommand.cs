using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Teachers.UpdateTeacher;

public class UpdateTeacherCommand(TeacherUpdateDto dto  , int id)   :  IRequest<TeacherResponseDto>
{
    public int Id { get; set; } = id;
    public TeacherUpdateDto TeacherUpdateDto { get; set; } = dto;
}

public class UpdateTeacherCommandHadnler(ITeacherRepository repo, IMapper mapper) : IRequestHandler<UpdateTeacherCommand, TeacherResponseDto>
{
    public  async Task<TeacherResponseDto> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)

    {
        var teacher = await repo.GetByIdAsync(request.Id);

        if (teacher == null)
            throw new Exception("Teacher Not Found!");

        mapper.Map(request.TeacherUpdateDto, teacher);

        repo.Update(teacher);
        await repo.SaveChangesAsync();

        return mapper.Map<TeacherResponseDto>(teacher);
    }
}
