namespace Projeto_Alura.Application.DTOs;

public class UpdateUsersDTO
{
    public long Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }
}
