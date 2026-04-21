using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Domain.Interfaces;

public interface ICursosRepository
{
    Task<IEnumerable<Cursos>> GetAllCursosAsync();
    Task<Cursos> GetCursoByIdAsync(long id);
    Task AddCursoAsync(Cursos curso);
    Task UpdateCursoAsync(Cursos curso);
    Task DeleteCursoAsync(long id);
}
