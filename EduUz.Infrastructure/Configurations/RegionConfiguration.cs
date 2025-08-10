using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class RegionConfiguration : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.ToTable("Regions");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Region { Id = 1, Name = "Andijon viloyati" },
            new Region { Id = 2, Name = "Buxoro viloyati" },
            new Region { Id = 3, Name = "Farg'ona viloyati" },
            new Region { Id = 4, Name = "Jizzax viloyati" },
            new Region { Id = 5, Name = "Xorazm viloyati" },
            new Region { Id = 6, Name = "Namangan viloyati" },
            new Region { Id = 7, Name = "Navoiy viloyati" },
            new Region { Id = 8, Name = "Qashqadaryo viloyati" },
            new Region { Id = 9, Name = "Qoraqalpog'iston Respublikasi" },
            new Region { Id = 10, Name = "Samarqand viloyati" },
            new Region { Id = 11, Name = "Sirdaryo viloyati" },
            new Region { Id = 12, Name = "Surxondaryo viloyati" },
            new Region { Id = 13, Name = "Toshkent shahri" },
            new Region { Id = 14, Name = "Toshkent viloyati" }
        );
    }
}