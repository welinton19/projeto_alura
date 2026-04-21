using Projeto_Alura.Domain.Interfaces;
using Projeto_Alura.Infrastructure.Data;

namespace Projeto_Alura.Infrastructure.Repositories;

public class LoginRepositories : ILoginRepository
{
    private readonly AluraDbContext _dbContext;

    public LoginRepositories(AluraDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<bool> LoginAsync(string email, string senha)
    {
        await _dbContext.Users.FindAsync(email, senha);
        return true;
    }
}
