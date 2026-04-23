using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Infrastructure.Entities_Configuration;

public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    

    public void Configure(EntityTypeBuilder<Login> builder)
    {
       builder.HasKey(l => l.Id);
        builder.Property(l => l.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(l => l.Password)
            .IsRequired()
            .HasMaxLength(100);
    }
}
