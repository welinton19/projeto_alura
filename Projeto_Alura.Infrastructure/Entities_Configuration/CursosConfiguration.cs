using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Infrastructure.Entities_Configuration;

public class CursosConfiguration : IEntityTypeConfiguration<Cursos>
{
    public void Configure(EntityTypeBuilder<Cursos> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(50);
        builder.Property(x => x.Description)
            .HasMaxLength(500);
    }
}
