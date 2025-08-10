using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class AttendanceConfiguration : IEntityTypeConfiguration<Attendance>
{
    public void Configure(EntityTypeBuilder<Attendance> builder)
    {
        builder.ToTable("Attendances");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Status)
            .IsRequired()
            .HasConversion<string>();

        builder.HasOne(a => a.Timetable)
            .WithMany(t => t.Attendances)
            .HasForeignKey(a => a.TimetableId);

        builder.HasOne(a => a.Student)
            .WithMany(s => s.Attendances)
            .HasForeignKey(a => a.StudentId);

        builder.HasIndex(a => new { a.TimetableId, a.StudentId }).IsUnique();
    }
}