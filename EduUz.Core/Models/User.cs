using System.IO;
using System.Text.Json.Serialization;
using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }
    public string? ImagePath { get; set; }
    public string PasswordHash { get; set; }

    public int RoleId { get; set; }
    [JsonIgnore]
    public Role Role { get; set; }

    public int? SchoolId { get; set; }
    [JsonIgnore]
    public School School { get; set; }

    // Role-specific navigation properties
    [JsonIgnore]
    public Teacher Teacher { get; set; }
    [JsonIgnore]
    public Student Student { get; set; }
    [JsonIgnore]
    public Parent Parent { get; set; }
    [JsonIgnore]
    public Director Director { get; set; }
}