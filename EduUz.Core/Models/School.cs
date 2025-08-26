namespace EduUz.Core.Models;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public  City City { get; set; }
    public  ICollection<Class> Classes { get; set; } = new List<Class>();
    public  ICollection<User> Users { get; set; } = new List<User>();
}