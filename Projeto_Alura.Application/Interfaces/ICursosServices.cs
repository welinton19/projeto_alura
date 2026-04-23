using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Application.Interfaces;

public interface ICursosServices
{
    
    Task<Cursos> CreateCurosAsync(CreateCursosDTO createCursos);
    Task<Cursos> UpdateCursosAsync(UpdateCursosDTO updateCursos);
    Task<List<Cursos>> GetAllCursosAsync(GetAllCursosDTO getAllCursos);
    Task<Cursos> GetCursosByIdAsync(GetCursosByIdDTO getCursosById);
    Task<Cursos> DeleteCursosAsync(DeleteCursosDTO deleteCursos);
}
