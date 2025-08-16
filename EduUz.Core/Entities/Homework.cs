using System;
using System.Collections.Generic;

namespace EduUz.Core.Entities
{
    public class Homework
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Teacher Teacher { get; set; }
        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<HomeworkMaterial> Materials { get; set; }
    }

    public class HomeworkMaterial
    {
        public int Id { get; set; }
        public int HomeworkId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Homework Homework { get; set; }
    }

    public class HomeworkSubmission
    {
        public int Id { get; set; }
        public int HomeworkId { get; set; }
        public int StudentId { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedAt { get; set; }

        // Navigation properties
        public virtual Homework Homework { get; set; }
        public virtual Student Student { get; set; }
    }

    public class HomeworkSubmissionFile
    {
        public int Id { get; set; }
        public int SubmissionId { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual HomeworkSubmission Submission { get; set; }
    }
}