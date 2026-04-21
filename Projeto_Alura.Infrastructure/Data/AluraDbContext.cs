using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Infrastructure.Data;

public class AluraDbContext : DbContext
{
    public AluraDbContext(DbContextOptions<AluraDbContext> options) : base(options)
    {
    }

    public DbSet<Cursos> Cursos { get; set; }
    public DbSet<Login> Login {  get; set; }
    public DbSet<Matriculas> Matriculas { get; set; }
    public DbSet<Users> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
