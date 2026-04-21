namespace Projeto_Alura.Domain.Interfaces;

public interface ILoginRepository
{
    Task<bool> LoginAsync(string email, string senha);
}
