using Projeto_Alura.Domain.Enum;

namespace Projeto_Alura.Application.DTOs;

public class GetAllUsersDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public Roles Roles { get; set; }
}
