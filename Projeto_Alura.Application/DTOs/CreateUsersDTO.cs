using Projeto_Alura.Domain.Enum;

namespace Projeto_Alura.Application.DTOs;

public class CreateUsersDTO
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
    public Roles Role { get; set; }
}
