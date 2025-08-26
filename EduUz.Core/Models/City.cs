using System.Text.Json.Serialization;

namespace EduUz.Core.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }
    [JsonIgnore]
    public  Region Region { get; set; }
    public  ICollection<School> Schools { get; set; } = new List<School>();
}
