using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Alura.Application.DTOs;

public class CreateCursosDTO
{
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Type { get; set; }
}
