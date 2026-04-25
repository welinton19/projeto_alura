using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;
using Projeto_Alura.Infrastructure.Data;

namespace Projeto_Alura.Infrastructure.Repositories;

public class MatriculaRepositories : IMatriculasRepository
{
    private readonly AluraDbContext _dbcontext;

    public MatriculaRepositories(AluraDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Matriculas> AddMatriculaAsync(Matriculas matricula)
    {
        _dbcontext.Matriculas.Add(matricula);
        await _dbcontext.SaveChangesAsync();
        return matricula;
    }

    public async Task<Matriculas> DeleteMatriculaAsync(long id)
    {
        var matricula = await _dbcontext.Matriculas.FindAsync(id);
        if (matricula != null)
        {
            _dbcontext.Matriculas.Remove(matricula);
            await _dbcontext.SaveChangesAsync();
        }
        return (matricula);
    }

    public async Task<IEnumerable<Matriculas>> GetAllMatriculasAsync()
    {
        return await _dbcontext.Matriculas.ToListAsync();
    }

    public async Task<Matriculas> GetMatriculaByIdAsync(long id)
    {
        return await _dbcontext.Matriculas.FindAsync(id);
    }

    public async Task<Matriculas> UpdateMatriculaAsync(Matriculas matricula)
    {
        _dbcontext.Matriculas.Update(matricula);
        await _dbcontext.SaveChangesAsync();
        return matricula;
    }
    
}
