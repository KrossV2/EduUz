using System.IO;
using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public int RoleId { get; set; }
    public Role Role { get; set; }

    public int? SchoolId { get; set; }
    public School School { get; set; }

    // Role-specific navigation properties
    public Teacher Teacher { get; set; }
    public Student Student { get; set; }
    public Parent Parent { get; set; }
    public Director Director { get; set; }
}