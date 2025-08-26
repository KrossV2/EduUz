using System.Text.Json.Serialization;
using System.Xml;

    namespace EduUz.Core.Models;

    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    [JsonIgnore]
        public User User { get; set; }
        public bool IsHomeroomTeacher { get; set; }
    [JsonIgnore]
        public ICollection<Class> HomeroomClasses { get; set; } = new List<Class>();

        // Qo'shimcha property
        public string FullName => $"{User?.FirstName} {User?.LastName}";
    [JsonIgnore]
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }