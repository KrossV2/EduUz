using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.ToTable("Grades");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.GradeType)
            .IsRequired()
            .HasConversion<string>();

        builder.Property(g => g.Value)
            .IsRequired();

        builder.Property(g => g.Date)
            .IsRequired();

        builder.Property(g => g.IsPendingApproval)
            .HasDefaultValue(false);

        builder.HasOne(g => g.Student)
            .WithMany(s => s.Grades)
            .HasForeignKey(g => g.StudentId);

        builder.HasOne(g => g.TeacherSubject)
            .WithMany()
            .HasForeignKey(g => g.TeacherSubjectId);

        builder.HasOne(g => g.OriginalGrade)
            .WithMany()
            .HasForeignKey(g => g.OriginalGradeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}