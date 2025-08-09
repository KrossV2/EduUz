namespace EduUz.Core.Models;

public class School
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public City City { get; set; }
    public int DirectorId { get; set; }
    public User Director { get; set; }
}