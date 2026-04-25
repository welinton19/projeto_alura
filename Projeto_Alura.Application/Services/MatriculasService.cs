using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;

namespace Projeto_Alura.Application.Services;

public class MatriculasService : IMatriculasServices
{
    private readonly IMatriculasRepository _matriculasRepository;

    public MatriculasService(IMatriculasRepository matriculasRepository)
    {
        _matriculasRepository = matriculasRepository;
    }

    public async Task<Matriculas> CreateMatriculasAsync(CreateMatriculasDTO createMatriculasDTO)
    {
        
        if (createMatriculasDTO == null)
            throw new ArgumentNullException(nameof(createMatriculasDTO));

        
        var matricula = new Matriculas
        {
            Id = createMatriculasDTO.Id,
            UserId = createMatriculasDTO.UserId,
            CursoId = createMatriculasDTO.CursoId,
            DataMatricula = DateTime.UtcNow
        };

        
        var criarMatricula = await _matriculasRepository.AddMatriculaAsync(matricula);

        return criarMatricula;
    }

    public async Task<Matriculas> DeleteMatriculasAsync(DeleteMatriculasDTO deleteMatriculasDTO)
    {
        var exclruirmatricula = await _matriculasRepository.DeleteMatriculaAsync(deleteMatriculasDTO.Id);
        if (exclruirmatricula == null)
            return null;
        return exclruirmatricula;
    }

    public async Task<Matriculas> GetById(GetMatriculasByIdDTO getMatriculasByIdDTO)
    {
        var idmatricula = await _matriculasRepository.GetMatriculaByIdAsync(id: getMatriculasByIdDTO.Id);
        if (idmatricula == null)
            return null; 
        return idmatricula;
    }

    public async Task<List<Matriculas>> GetMatriculasAsync(GetAllMatriculasDTO getAllMatriculas)
    {
        var listamatriculas = await _matriculasRepository.GetAllMatriculasAsync();
        var Matriculas = new List<Matriculas>();
        foreach(var matricula  in listamatriculas) 
        {
            Matriculas.Add(new Matriculas 
            {
                Id = matricula.Id,
                UserId = matricula.UserId,
                CursoId = matricula.CursoId,
                DataMatricula = matricula.DataMatricula,
            });
        }
        return Matriculas;
    }

    public async Task<Matriculas> UpdateMatriculasAsync(UpdateMatriculasDTO updateMatriculasDTO)
    {
        var atualizar = await _matriculasRepository.UpdateMatriculaAsync(new Matriculas 
        {
            Id = updateMatriculasDTO.Id,
            UserId = updateMatriculasDTO.UserId,
            DataMatricula = updateMatriculasDTO .DataMatricula,
        });
        return atualizar;
    }
}
