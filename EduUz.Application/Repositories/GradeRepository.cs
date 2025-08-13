using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Repositories;

public class GradeRepository(EduUzDbContext context) :  Repository<Grade>(context) , IGradeRepository
{
    public async Task<List<Grade>> GetFilteredGradesAsync(GradeFilterDto filter)
    {
        var query = context.Grades
            .Include(g => g.Student)
            .Include(g => g.TeacherSubject)
            .ThenInclude(ts => ts.Subject)
            .Include(g => g.TeacherSubject.Teacher)
            .AsQueryable();

        if (filter.ClassId.HasValue)
            query = query.Where(g => g.Student.ClassId == filter.ClassId);

        if (filter.SubjectId.HasValue)
            query = query.Where(g => g.TeacherSubject.SubjectId == filter.SubjectId);

        if (filter.StudentId.HasValue)
            query = query.Where(g => g.StudentId == filter.StudentId);

        if (filter.GradeType.HasValue)
            query = query.Where(g => g.GradeType == filter.GradeType);

        if (filter.FromDate.HasValue)
            query = query.Where(g => g.Date >= filter.FromDate);

        if (filter.ToDate.HasValue)
            query = query.Where(g => g.Date <= filter.ToDate);

        return await query.ToListAsync();
    }

    public async Task<List<Grade>> GetGradesByStudentAsync(int studentId)
        => await context.Grades
            .Where(g => g.StudentId == studentId)
            .ToListAsync();

    public async Task<List<Grade>> GetPendingApprovalsAsync()
        => await context.Grades
            .Where(g => g.IsPendingApproval)
            .ToListAsync();
}
