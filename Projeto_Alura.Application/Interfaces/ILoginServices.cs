using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Application.Interfaces;

public interface ILoginServices
{
    Task<bool> LoginAsync(LoginDTO login);
}
