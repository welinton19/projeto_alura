using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;

namespace Projeto_Alura.Application.Services;

public class CursosService : ICursosServices
{
    private readonly ICursosRepository _cursosRepository;

    public CursosService(ICursosRepository cursosRepository)
    {
        _cursosRepository = cursosRepository;
    }

    public Task<Cursos> CreateCurosAsync(CreateCursosDTO createCursos)
    {
        throw new NotImplementedException();
    }

    public Task<Cursos> DeleteCursosAsync(DeleteCursosDTO deleteCursos)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cursos>> GetAllCursosAsync(GetAllCursosDTO getAllCursos)
    {
        throw new NotImplementedException();
    }

    public Task<Cursos> GetCursosByIdAsync(GetCursosByIdDTO getCursosById)
    {
        throw new NotImplementedException();
    }

    public Task<Cursos> UpdateCursosAsync(UpdateCursosDTO updateCursos)
    {
        throw new NotImplementedException();
    }
}
