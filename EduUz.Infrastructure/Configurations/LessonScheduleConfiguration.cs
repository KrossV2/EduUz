using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class LessonScheduleConfiguration : IEntityTypeConfiguration<LessonSchedule>
{
    public void Configure(EntityTypeBuilder<LessonSchedule> builder)
    {
        builder.ToTable("LessonSchedules");
        builder.HasKey(ls => ls.Id);

        builder.Property(ls => ls.DayOfWeek)
            .IsRequired();

        builder.Property(ls => ls.LessonNumber)
            .IsRequired();

        builder.HasOne(ls => ls.Class)
            .WithMany(c => c.Schedules)
            .HasForeignKey(ls => ls.ClassId);

        builder.HasOne(ls => ls.TeacherSubject)
            .WithMany()
            .HasForeignKey(ls => ls.TeacherSubjectId);

        builder.HasIndex(ls => new { ls.ClassId, ls.DayOfWeek, ls.LessonNumber }).IsUnique();
    }
}