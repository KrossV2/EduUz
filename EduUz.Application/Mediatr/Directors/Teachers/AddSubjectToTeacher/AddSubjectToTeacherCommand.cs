using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Directors.Teachers.AddSubjectToTeacher;

public class AddSubjectToTeacherCommand(TeacherSubjectCreateDto dto) : IRequest<TeacherResponseDto>
{
    public TeacherSubjectCreateDto TeacherSubjectCreateDto { get; set; } = dto;
}

public class AddSubjectToTeacherCommandHandler(EduUzDbContext context, ITeacherRepository repo , IMapper mapper) : IRequestHandler<AddSubjectToTeacherCommand, TeacherResponseDto>
{
    public async Task<TeacherResponseDto> Handle(AddSubjectToTeacherCommand request, CancellationToken cancellationToken)
    {
        var teacherExists = await repo.GetByIdAsync(request.TeacherSubjectCreateDto.TeacherId);
        var subjectExists = await context.Subjects.FindAsync(request.TeacherSubjectCreateDto.SubjectId);

        if (teacherExists == null)
            throw new Exception("Teacher not found!");

        if (subjectExists == null)
            throw new Exception("Subject not found");

        // Yangi TeacherSubject obyektini yaratamiz
        var teacherSubject = new TeacherSubject
        {
            TeacherId = teacherExists.Id,
            SubjectId = subjectExists.Id,
            Teacher = teacherExists,
            Subject = subjectExists
        };

        teacherExists.TeacherSubjects.Add(teacherSubject);

        await context.SaveChangesAsync(cancellationToken);

        var response = mapper.Map<TeacherResponseDto>(teacherExists);

        return response;
    }

}
