namespace Projeto_Alura.Domain.Interfaces;

public interface ILogin
{
    Task<bool> LoginAsync(string email, string senha);
}
