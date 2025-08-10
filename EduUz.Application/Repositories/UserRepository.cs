using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;

namespace EduUz.Application.Repositories;

public class UserRepository(EduUzDbContext context) : Repository<User>(context) , IUserRepository
{
}
