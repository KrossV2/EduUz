using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teachers.Grades.UpdateGrade;


public record UpdateGradeCommand(int Id, GradeUpdateDto Dto) : IRequest<GradeResponseDto>;

public class UpdateGradeCommandHandler(EduUzDbContext context)
    : IRequestHandler<UpdateGradeCommand, GradeResponseDto>
{
    public async Task<GradeResponseDto> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
    {
        var grade = await context.Grades
            .Include(g => g.Student).ThenInclude(s => s.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Teacher).ThenInclude(t => t.User)
            .Include(g => g.TeacherSubject).ThenInclude(ts => ts.Subject)
            .FirstOrDefaultAsync(g => g.Id == request.Id, cancellationToken);

        if (grade == null) throw new Exception("Grade not found");

        if (request.Dto.Value.HasValue)
            grade.Value = request.Dto.Value.Value;

        grade.ChangeReason = request.Dto.ChangeReason;
        grade.IsPendingApproval = true;

        await context.SaveChangesAsync(cancellationToken);

        return new GradeResponseDto(
            grade.Id,
            $"{grade.Student.User.FirstName} {grade.Student.User.LastName}",
            grade.TeacherSubject.Subject.Name,
            grade.TeacherSubject.Teacher.FullName,
            grade.GradeType.ToString(),
            grade.Value,
            grade.Date,
            grade.IsPendingApproval,
            grade.ChangeReason
        );
    }
}