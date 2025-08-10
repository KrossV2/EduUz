
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

        builder.HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Parent>(p => p.UserId);
    }
}