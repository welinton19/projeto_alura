using Projeto_Alura.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Projeto_Alura.Application.DTOs;

public class LoginDTO
{
    [Required]
    [EmailAddress(ErrorMessage =  "O campo {0} deve ser um endereço de email válido.")]
    public string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "O campo {0} deve conter no mínimo {1} caracteres.")]
    public string Password { get; set; }
    public Roles Role { get; set; }
}
