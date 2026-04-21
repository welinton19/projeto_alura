using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Domain.Interfaces;

public interface IMatriculasRepository
{
    Task<IEnumerable<Matriculas>> GetAllMatriculasAsync();
    Task<Matriculas> GetMatriculaByIdAsync(long id);
    Task AddMatriculaAsync(Matriculas matricula);
    Task UpdateMatriculaAsync(Matriculas matricula);
    Task DeleteMatriculaAsync(long id);
}
