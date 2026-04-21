using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Infrastructure.Entities_Configuration;

public class MatriculasConfiguration : IEntityTypeConfiguration<Matriculas>
{
    public void Configure(EntityTypeBuilder<Matriculas> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.CursoId) 
            .IsRequired();
        builder.Property(x => x.DataMatricula)
            .IsRequired();
    }
}
