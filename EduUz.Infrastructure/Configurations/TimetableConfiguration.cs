using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class TimetableConfiguration : IEntityTypeConfiguration<Timetable>
{
    public void Configure(EntityTypeBuilder<Timetable> builder)
    {
        builder.ToTable("Timetables");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.LessonDate)
            .IsRequired();

        builder.Property(t => t.StartTime)
            .IsRequired();

        builder.Property(t => t.EndTime)
            .IsRequired();

        builder.HasOne(t => t.LessonSchedule)
            .WithMany()
            .HasForeignKey(t => t.LessonScheduleId);
    }
}