    using System.Xml;

    namespace EduUz.Core.Models;

    public class Teacher
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public   User User { get; set; }
        public bool IsHomeroomTeacher { get; set; }
        public ICollection<Class> HomeroomClasses { get; set; } = new List<Class>();

        // Qo'shimcha property
        public string FullName => $"{User?.FirstName} {User?.LastName}";
        public ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
    }