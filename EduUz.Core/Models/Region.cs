namespace EduUz.Core.Models;

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}

