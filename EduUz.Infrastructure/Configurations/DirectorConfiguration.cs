
using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("Directors");
        builder.HasKey(d => d.Id);

        // User relationship is configured in UserConfiguration
        // builder.HasOne(d => d.User)
        //     .WithOne(u => u.Director)
        //     .HasForeignKey<Director>(d => d.UserId);

        builder.HasOne(d => d.School)
            .WithOne()
            .HasForeignKey<Director>(d => d.SchoolId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}