using Projeto_Alura.Application.DTOs;

namespace Projeto_Alura.Application.Interfaces;

public interface ITokenServices
{
    Task<string> GerartToken(string email, string role);
}
