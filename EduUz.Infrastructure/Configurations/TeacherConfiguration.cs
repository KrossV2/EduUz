
using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.IsHomeroomTeacher)
            .HasDefaultValue(false);

        // User relationship is configured in UserConfiguration
        // builder.HasOne(t => t.User)
        //     .WithOne(u => u.Teacher)
        //     .HasForeignKey<Teacher>(t => t.UserId);
    }
}