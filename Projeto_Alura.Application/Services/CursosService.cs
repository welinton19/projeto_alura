using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Exceptions;
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

    public async Task<Cursos> CreateCurosAsync(CreateCursosDTO createCursos)
    {
        if (createCursos == null)
            throw new ArgumentException(nameof(createCursos));

        var curso = new Cursos 
        {
           
            Name = createCursos.Name,
            Description = createCursos.Description,
            Type = createCursos.Type
        };

        var criarcurso = await _cursosRepository.AddCursoAsync(curso);
        
        return criarcurso;
    }

    public async Task<Cursos> DeleteCursosAsync(DeleteCursosDTO deleteCursos)
    {
        var deletacurso = await _cursosRepository.DeleteCursoAsync(deleteCursos.Id);
        if (deletacurso == null)
            return null;
        return deletacurso;
    }

    public async Task<List<Cursos>> GetAllCursosAsync(GetAllCursosDTO getAllCursos)
    {
        var allcurso = await _cursosRepository.GetAllCursosAsync();
        var cursos = new List<Cursos>();
        foreach (var curso in allcurso) 
        {
            cursos.Add(new Cursos
            {
                Id = curso.Id,
                Name = curso.Name,
                Description= curso.Description,
                Type = curso.Type
            });
        }
        return cursos;
    }

    public async Task<Cursos> GetCursosByIdAsync(GetCursosByIdDTO getCursosById)
    {
        var cursoid = await _cursosRepository.GetCursoByIdAsync(getCursosById.Id);
        if (cursoid == null)
            throw new NotFoundExceptions("Cusos", getCursosById);
        return cursoid;
    }

    public async Task<Cursos> UpdateCursosAsync(UpdateCursosDTO updateCursos)
    {
        var atualizacurso = await _cursosRepository.UpdateCursoAsync(new Cursos 
        {
            Id = updateCursos.Id,
            Description = updateCursos.Description
        });
        return atualizacurso;
    }
}
