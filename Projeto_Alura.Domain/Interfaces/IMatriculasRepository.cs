using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Domain.Interfaces;

public interface IMatriculasRepository
{
    Task<IEnumerable<Matriculas>> GetAllMatriculasAsync();
    Task<Matriculas> GetMatriculaByIdAsync(long id);
    Task<Matriculas> AddMatriculaAsync(Matriculas matricula);
    Task<Matriculas> UpdateMatriculaAsync(Matriculas matricula);
    Task<Matriculas> DeleteMatriculaAsync(long id);
}
