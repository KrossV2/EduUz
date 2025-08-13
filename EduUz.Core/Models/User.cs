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
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpiry { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpiry { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? LastLogin { get; set; }
    public bool IsActive { get; set; } = true;

    public int RoleId { get; set; }
    public virtual Role Role { get; set; }

    public int? SchoolId { get; set; }
    public virtual School School { get; set; }

    // Role-specific navigation properties
    public virtual Teacher Teacher { get; set; }
    public virtual Student Student { get; set; }
    public virtual Parent Parent { get; set; }
    public virtual Director Director { get; set; }
}