using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Teacher.Grades.CreateGrade;

public record CreateGradeCommand(GradeCreateDto Dto) : IRequest<GradeResponseDto>;

public class CreateGradeCommandHandler(EduUzDbContext context)
    : IRequestHandler<CreateGradeCommand, GradeResponseDto>
{
    public async Task<GradeResponseDto> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
    {
        var student = await context.Students.FindAsync(request.Dto.StudentId);
        var teacherSubject = await context.Set<TeacherSubject>().FindAsync(request.Dto.TeacherSubjectId);

        if (student == null) throw new Exception("Student not found");
        if (teacherSubject == null) throw new Exception("TeacherSubject not found");

        var grade = new Grade
        {
            StudentId = request.Dto.StudentId,
            TeacherSubjectId = request.Dto.TeacherSubjectId,
            GradeType = request.Dto.GradeType,
            Value = request.Dto.Value,
            Date = request.Dto.Date,
            IsPendingApproval = false
        };

        context.Grades.Add(grade);
        await context.SaveChangesAsync(cancellationToken);

        return new GradeResponseDto(
            grade.Id,
            $"{student.User.FirstName} {student.User.LastName}",
            teacherSubject.Subject.Name,
            teacherSubject.Teacher.FullName,
            grade.GradeType.ToString(),
            grade.Value,
            grade.Date,
            grade.IsPendingApproval,
            grade.ChangeReason
        );
    }
}
