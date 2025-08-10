using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;

namespace EduUz.Application.Repositories;

public class GradeRepository(EduUzDbContext context) :  Repository<Grade>(context) , IGradeRepository
{
}
