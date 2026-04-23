using Projeto_Alura.Domain.Enum;

namespace Projeto_Alura.Application.DTOs;

public class UsersDTO
{
    public long Id { get; set; }
    public Roles Roles { get; set; }
}
