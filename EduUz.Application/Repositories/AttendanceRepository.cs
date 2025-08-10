using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;

namespace EduUz.Application.Repositories;

public class AttendanceRepository(EduUzDbContext context) : Repository<Attendance>(context) , IAttendanceRepository
{
}
