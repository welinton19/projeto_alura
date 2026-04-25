using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Domain.Interfaces;

public interface ICursosRepository
{
    Task<IEnumerable<Cursos>> GetAllCursosAsync();
    Task<Cursos> GetCursoByIdAsync(long id);
    Task<Cursos> AddCursoAsync(Cursos curso);
    Task<Cursos> UpdateCursoAsync(Cursos curso);
    Task<Cursos> DeleteCursoAsync(long id);
}
