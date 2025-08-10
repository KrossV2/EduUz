using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class BehaviorRecordConfiguration : IEntityTypeConfiguration<BehaviorRecord>
{
    public void Configure(EntityTypeBuilder<BehaviorRecord> builder)
    {
        builder.ToTable("BehaviorRecords");
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Description)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(b => b.Points)
            .IsRequired();

        builder.Property(b => b.RecordDate)
            .IsRequired();

        builder.HasOne(b => b.Student)
            .WithMany(s => s.BehaviorRecords)
            .HasForeignKey(b => b.StudentId);

        builder.HasOne(b => b.Teacher)
            .WithMany()
            .HasForeignKey(b => b.TeacherId);
    }
}