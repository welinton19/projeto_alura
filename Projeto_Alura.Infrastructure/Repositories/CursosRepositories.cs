using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;
using Projeto_Alura.Infrastructure.Data;

namespace Projeto_Alura.Infrastructure.Repositories;

public class CursosRepositories : ICursosRepository
{
    private readonly AluraDbContext _dbcontext;

    public CursosRepositories(AluraDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Cursos> AddCursoAsync(Cursos curso)
    {
        _dbcontext.Cursos.Add(curso);
        await _dbcontext.SaveChangesAsync();
        return curso;
    }

    public async Task<Cursos> DeleteCursoAsync(long id)
    {
        var curso = await _dbcontext.Cursos.FindAsync(id);
        if (curso != null)
        {
            _dbcontext.Cursos.Remove(curso);
            await _dbcontext.SaveChangesAsync();
        }
        return curso;
    }

    public async Task<IEnumerable<Cursos>> GetAllCursosAsync()
    {
        return await _dbcontext.Cursos.ToListAsync();
    }

    public async Task<Cursos> GetCursoByIdAsync(long id)
    {
        return await _dbcontext.Cursos.FindAsync(id);
    }

    public async Task<Cursos> UpdateCursoAsync(Cursos curso)
    {
        _dbcontext.Cursos.Update(curso);
        await _dbcontext.SaveChangesAsync();
        return curso;
    }
}
