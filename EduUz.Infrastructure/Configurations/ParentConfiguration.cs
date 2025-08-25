
using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class ParentConfiguration : IEntityTypeConfiguration<Parent>
{
    public void Configure(EntityTypeBuilder<Parent> builder)
    {
        builder.ToTable("Parents");
        builder.HasKey(p => p.Id);

        // User relationship is configured in UserConfiguration
        // builder.HasOne(p => p.User)
        //     .WithOne(u => u.Parent)
        //     .HasForeignKey<Parent>(p => p.UserId);
    }
}