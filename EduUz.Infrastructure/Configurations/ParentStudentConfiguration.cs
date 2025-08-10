using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class ParentStudentConfiguration : IEntityTypeConfiguration<ParentStudent>
{
    public void Configure(EntityTypeBuilder<ParentStudent> builder)
    {
        builder.ToTable("ParentStudents");
        builder.HasKey(ps => ps.Id);

        builder.HasOne(ps => ps.Parent)
            .WithMany(p => p.Students)
            .HasForeignKey(ps => ps.ParentId);

        builder.HasOne(ps => ps.Student)
            .WithMany(s => s.Parents)
            .HasForeignKey(ps => ps.StudentId);

        builder.HasIndex(ps => new { ps.ParentId, ps.StudentId }).IsUnique();
    }
}