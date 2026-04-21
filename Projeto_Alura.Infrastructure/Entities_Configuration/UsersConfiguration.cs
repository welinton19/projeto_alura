using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Infrastructure.Entities_Configuration;

public class UsersConfiguration : IEntityTypeConfiguration<Users>
{
    public void Configure(EntityTypeBuilder<Users> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(x => x.Password)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.Role)
            .IsRequired();
    }
}
