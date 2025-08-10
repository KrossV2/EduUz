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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduUzDbContext).Assembly);
    }
}

