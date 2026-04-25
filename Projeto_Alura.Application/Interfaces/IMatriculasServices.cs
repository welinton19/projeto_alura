using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Application.Interfaces;

public interface IMatriculasServices
{
    Task <List<Matriculas>> GetMatriculasAsync (GetAllMatriculasDTO getAllMatriculas);
    Task<Matriculas> CreateMatriculasAsync(CreateMatriculasDTO createMatriculasDTO);
    Task<Matriculas> GetById(GetMatriculasByIdDTO getMatriculasByIdDTO);
    Task<Matriculas> UpdateMatriculasAsync(UpdateMatriculasDTO updateMatriculasDTO);
    Task<Matriculas> DeleteMatriculasAsync(DeleteMatriculasDTO deleteMatriculasDTO);
}
