using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Security.Claims;
using System.Xml;
using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Database;

public class EduUzDbContext : DbContext
{
    public EduUzDbContext(DbContextOptions<EduUzDbContext> options) : base(options)
    {
    }

    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<BehaviorRecord> BehaviorRecords { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<LessonSchedule> LessonSchedules { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Parent> Parents { get; set; }
    public DbSet<ParentStudent> ParentStudents { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<School> Schools { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<Timetable> Timetables { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<GradeChangeRequest> GradeChangeRequests { get; set; }
    public DbSet<HomeworkSubmission> HomeworkSubmissions { get; set; }
    public DbSet<Excuse> Excuses { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1. User Relationships (One-to-One)
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.User)
            .WithOne(u => u.Teacher)
            .HasForeignKey<Teacher>(t => t.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.User)
            .WithOne(u => u.Student)
            .HasForeignKey<Student>(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Parent>()
            .HasOne(p => p.User)
            .WithOne(u => u.Parent)
            .HasForeignKey<Parent>(p => p.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Director>()
            .HasOne(d => d.User)
            .WithOne(u => u.Director)
            .HasForeignKey<Director>(d => d.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 2. School Relationships
        modelBuilder.Entity<School>()
            .HasOne(s => s.Director)
            .WithOne(d => d.School)
            .HasForeignKey<School>(s => s.DirectorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Director>()
            .HasOne(d => d.School)
            .WithOne(s => s.Director)
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.SetNull);

        // 3. Class Relationships
        modelBuilder.Entity<Class>()
            .HasOne(c => c.School)
            .WithMany(s => s.Classes)
            .HasForeignKey(c => c.SchoolId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Class>()
            .HasOne(c => c.HomeroomTeacher)
            .WithMany(t => t.HomeroomClasses)
            .HasForeignKey(c => c.HomeroomTeacherId)
            .OnDelete(DeleteBehavior.SetNull);

        // 4. Student Relationships
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Class)
            .WithMany(c => c.Students)
            .HasForeignKey(s => s.ClassId)
            .OnDelete(DeleteBehavior.SetNull);

        // 5. Many-to-Many: ParentStudent
        modelBuilder.Entity<ParentStudent>()
            .HasKey(ps => ps.Id);

        modelBuilder.Entity<ParentStudent>()
            .HasOne(ps => ps.Parent)
            .WithMany(p => p.Students)
            .HasForeignKey(ps => ps.ParentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ParentStudent>()
            .HasOne(ps => ps.Student)
            .WithMany(s => s.Parents)
            .HasForeignKey(ps => ps.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // 6. Many-to-Many: TeacherSubject
        modelBuilder.Entity<TeacherSubject>()
            .HasKey(ts => ts.Id);

        modelBuilder.Entity<TeacherSubject>()
            .HasOne(ts => ts.Teacher)
            .WithMany(t => t.TeacherSubjects)
            .HasForeignKey(ts => ts.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<TeacherSubject>()
            .HasOne(ts => ts.Subject)
            .WithMany(s => s.TeacherSubjects)
            .HasForeignKey(ts => ts.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        // 7. Grade Relationships
        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.TeacherSubject)
            .WithMany()
            .HasForeignKey(g => g.TeacherSubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.OriginalGrade)
            .WithMany()
            .HasForeignKey(g => g.OriginalGradeId)
            .OnDelete(DeleteBehavior.SetNull);

        // 8. Attendance Relationships
        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Student)
            .WithMany(s => s.AttendanceRecords)
            .HasForeignKey(a => a.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Attendance>()
            .HasOne(a => a.Timetable)
            .WithMany(t => t.Attendances)
            .HasForeignKey(a => a.TimetableId)
            .OnDelete(DeleteBehavior.Cascade);

        // 9. BehaviorRecord Relationships
        modelBuilder.Entity<BehaviorRecord>()
            .HasOne(br => br.Student)
            .WithMany(s => s.BehaviorRecords)
            .HasForeignKey(br => br.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<BehaviorRecord>()
            .HasOne(br => br.Teacher)
            .WithMany()
            .HasForeignKey(br => br.TeacherId)
            .OnDelete(DeleteBehavior.Restrict);

        // 10. Homework Relationships
        modelBuilder.Entity<Homework>()
            .HasOne(h => h.TeacherSubject)
            .WithMany()
            .HasForeignKey(h => h.TeacherSubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Homework>()
            .HasOne(h => h.Class)
            .WithMany()
            .HasForeignKey(h => h.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        // 11. HomeworkSubmission Relationships
        modelBuilder.Entity<HomeworkSubmission>()
            .HasOne(hs => hs.Student)
            .WithMany()
            .HasForeignKey(hs => hs.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HomeworkSubmission>()
            .HasOne(hs => hs.Homework)
            .WithMany()
            .HasForeignKey(hs => hs.HomeworkId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<HomeworkSubmission>()
            .HasOne(hs => hs.Grade)
            .WithMany()
            .HasForeignKey(hs => hs.GradeId)
            .OnDelete(DeleteBehavior.SetNull);

        // 12. LessonSchedule Relationships
        modelBuilder.Entity<LessonSchedule>()
            .HasOne(ls => ls.Class)
            .WithMany(c => c.Schedules)
            .HasForeignKey(ls => ls.ClassId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<LessonSchedule>()
            .HasOne(ls => ls.TeacherSubject)
            .WithMany()
            .HasForeignKey(ls => ls.TeacherSubjectId)
            .OnDelete(DeleteBehavior.Restrict);

        // 13. Timetable Relationships
        modelBuilder.Entity<Timetable>()
            .HasOne(t => t.LessonSchedule)
            .WithMany()
            .HasForeignKey(t => t.LessonScheduleId)
            .OnDelete(DeleteBehavior.Cascade);

        // 14. Notification Relationships
        modelBuilder.Entity<Notification>()
            .HasOne(n => n.User)
            .WithMany()
            .HasForeignKey(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // 15. Excuse Relationships
        modelBuilder.Entity<Excuse>()
            .HasOne(e => e.Student)
            .WithMany()
            .HasForeignKey(e => e.StudentId)
            .OnDelete(DeleteBehavior.Cascade);

        // 16. GradeChangeRequest Relationships
        modelBuilder.Entity<GradeChangeRequest>()
            .HasOne(gcr => gcr.Grade)
            .WithMany()
            .HasForeignKey(gcr => gcr.GradeId)
            .OnDelete(DeleteBehavior.Cascade);

        // 17. Region-City Relationships
        modelBuilder.Entity<City>()
            .HasOne(c => c.Region)
            .WithMany(r => r.Cities)
            .HasForeignKey(c => c.RegionId)
            .OnDelete(DeleteBehavior.Restrict);

        // 18. Unique Constraints
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<Teacher>()
            .HasIndex(t => t.UserId)
            .IsUnique();

        modelBuilder.Entity<Student>()
            .HasIndex(s => s.UserId)
            .IsUnique();

        modelBuilder.Entity<Parent>()
            .HasIndex(p => p.UserId)
            .IsUnique();

        modelBuilder.Entity<Director>()
            .HasIndex(d => d.UserId)
            .IsUnique();

        // 19. Required Fields
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.PasswordHash)
            .IsRequired();

        modelBuilder.Entity<Role>(builder =>
        {
            builder.HasData(
            new Role { Id = 1, Name = "Admin", Description = "System administrator" },
            new Role { Id = 2, Name = "Director", Description = "School director" },
            new Role { Id = 3, Name = "Teacher", Description = "School teacher" },
            new Role { Id = 4, Name = "Student", Description = "Student" },
            new Role { Id = 5, Name = "Parent", Description = "Parent of student" }
        );
        });

        modelBuilder.Entity<Region>(builder =>
        {
            builder.HasData(
           new Region { Id = 1, Name = "Andijon viloyati" },
           new Region { Id = 2, Name = "Buxoro viloyati" },
           new Region { Id = 3, Name = "Farg'ona viloyati" },
           new Region { Id = 4, Name = "Jizzax viloyati" },
           new Region { Id = 5, Name = "Xorazm viloyati" },
           new Region { Id = 6, Name = "Namangan viloyati" },
           new Region { Id = 7, Name = "Navoiy viloyati" },
           new Region { Id = 8, Name = "Qashqadaryo viloyati" },
           new Region { Id = 9, Name = "Qoraqalpog'iston Respublikasi" },
           new Region { Id = 10, Name = "Samarqand viloyati" },
           new Region { Id = 11, Name = "Sirdaryo viloyati" },
           new Region { Id = 12, Name = "Surxondaryo viloyati" },
           new Region { Id = 13, Name = "Toshkent viloyati" }
       );
        });

        modelBuilder.Entity<Subject>(builder =>
        {
            builder.HasData(
            new Subject { Id = 1, Name = "Adabiyot" },
            new Subject { Id = 2, Name = "Algebra" },
            new Subject { Id = 3, Name = "Biologiya" },
            new Subject { Id = 4, Name = "Davlat va huquq asoslari" },
            new Subject { Id = 5, Name = "Fizika" },
            new Subject { Id = 6, Name = "Geografiya" },
            new Subject { Id = 7, Name = "Geometriya" },
            new Subject { Id = 8, Name = "Informatika" },
            new Subject { Id = 9, Name = "Ingliz tili" },
            new Subject { Id = 10, Name = "Iqtisod" },
            new Subject { Id = 11, Name = "Jahon tarixi" },
            new Subject { Id = 12, Name = "Kimyo" },
            new Subject { Id = 13, Name = "Ona tili" },
            new Subject { Id = 14, Name = "Rus tili" },
            new Subject { Id = 15, Name = "Tarbiya" },
            new Subject { Id = 16, Name = "Texnologiya" },
            new Subject { Id = 17, Name = "O'zbekiston tarixi" },
            new Subject { Id = 18, Name = "Chizmachilik" }
        );
        });
    }
}

