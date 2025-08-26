    namespace EduUz.Core.Models;

    public class Homework
    {
        public int Id { get; set; }
        public int TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string AttachmentPath { get; set; }
    }