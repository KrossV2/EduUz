namespace EduUz.Core.Models;

public class File
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string OriginalName { get; set; }
    public string ContentType { get; set; }
    public long Size { get; set; }
    public string FilePath { get; set; }
    public int UploadedById { get; set; }
    public virtual User UploadedBy { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public int? SchoolId { get; set; }
    public virtual School School { get; set; }
    public string FileType { get; set; } // Material, Assignment, etc.
}