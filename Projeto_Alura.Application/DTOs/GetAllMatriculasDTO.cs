using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Application.DTOs;

public class GetAllMatriculasDTO
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long CursoId { get; set; }
    public DateTime DataMatricula { get; set; }
}
