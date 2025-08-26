using System.Text.Json.Serialization;

namespace EduUz.Core.Models;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    [JsonIgnore]
    public  City City { get; set; }
    public int DirectorId { get; set; }
    [JsonIgnore]
    public Director Director { get; set; }
    [JsonIgnore]
    public  ICollection<Class> Classes { get; set; } = new List<Class>();
    [JsonIgnore]
    public  ICollection<User> Users { get; set; } = new List<User>();
}