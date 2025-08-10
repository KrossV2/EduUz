using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
{
    public void Configure(EntityTypeBuilder<Homework> builder)
    {
        builder.ToTable("Homeworks");
        builder.HasKey(h => h.Id);

        builder.Property(h => h.Description)
            .IsRequired()
            .HasMaxLength(1000);

        builder.Property(h => h.DueDate)
            .IsRequired();

        builder.Property(h => h.AttachmentPath)
            .HasMaxLength(255);

        builder.HasOne(h => h.TeacherSubject)
            .WithMany()
            .HasForeignKey(h => h.TeacherSubjectId);

        builder.HasOne(h => h.Class)
            .WithMany()
            .HasForeignKey(h => h.ClassId);
    }
}