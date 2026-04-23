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

    public Task<Matriculas> CreateMatriculasAsync(CreateMatriculasDTO createMatriculasDTO)
    {
        throw new NotImplementedException();
    }

    public Task<Matriculas> DeleteMatriculasAsync(DeleteMatriculasDTO deleteMatriculasDTO)
    {
        throw new NotImplementedException();
    }

    public Task<List<Matriculas>> GetMatriculasAsync(GetAllMatriculasDTO getAllMatriculas)
    {
        throw new NotImplementedException();
    }

    public Task<Matriculas> UpdateMatriculasAsync(UpdateMatriculasDTO updateMatriculasDTO)
    {
        throw new NotImplementedException();
    }
}
