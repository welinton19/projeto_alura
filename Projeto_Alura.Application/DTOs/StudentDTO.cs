namespace Projeto_Alura.Application.DTOs;

public class StudentDTO : UsersDTO
{
    public List<MatriculasDTO> Matriculas { get; set; }
}
