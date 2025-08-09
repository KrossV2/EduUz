using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

    public int? SchoolId { get; set; }
    public virtual School School { get; set; }
}
