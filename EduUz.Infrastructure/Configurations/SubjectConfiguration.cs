
using EduUz.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Infrastructure.Configurations;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.ToTable("Subjects");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasData(
            new Subject { Id = 1, Name = "Adabiyot" },
            new Subject { Id = 2, Name = "Algebra" },
            new Subject { Id = 3, Name = "Biologiya" },
            new Subject { Id = 4, Name = "Davlat va huquq asoslari" }, 
            new Subject { Id = 5, Name = "Fizika" },
            new Subject { Id = 6, Name = "Geografiya" },
            new Subject { Id = 7, Name = "Geometriya" }, 
            new Subject { Id = 8, Name = "Informatika" },
            new Subject { Id = 9, Name = "Ingliz tili" },
            new Subject { Id = 10, Name = "Iqtisod" }, 
            new Subject { Id = 11, Name = "Jahon tarixi" },
            new Subject { Id = 12, Name = "Kimyo" },
            new Subject { Id = 13, Name = "Ona tili" },
            new Subject { Id = 14, Name = "Rus tili" },
            new Subject { Id = 15, Name = "Tarbiya" },
            new Subject { Id = 16, Name = "Texnologiya" },
            new Subject { Id = 17, Name = "O'zbekiston tarixi" },
            new Subject { Id = 18, Name = "Chizmachilik" }
        );
    }
}