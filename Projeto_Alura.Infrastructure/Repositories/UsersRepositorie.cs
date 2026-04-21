using Microsoft.EntityFrameworkCore;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;
using Projeto_Alura.Infrastructure.Data;

namespace Projeto_Alura.Infrastructure.Repositories;

public class UsersRepositorie : IUserRepository
{
    private readonly AluraDbContext _dbcontext;

    public UsersRepositorie(AluraDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task AddUserAsync(Users user)
    {
        _dbcontext.Users.Add(user);
        await _dbcontext.SaveChangesAsync();
        return;
    }

    public async Task DeleteUserAsync(long id)
    {
        var user = await _dbcontext.Users.FindAsync(id);
        if (user != null)
        {
            _dbcontext.Users.Remove(user);
            await _dbcontext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Users>> GetAllUsersAsync()
    {
        return await _dbcontext.Users.ToListAsync();
    }

    public async Task<Users> GetUserByIdAsync(long id)
    {
        return await _dbcontext.Users.FindAsync(id);
    }

    public async Task UpdateUserAsync(Users user)
    {
        _dbcontext.Users.Update(user);
        await _dbcontext.SaveChangesAsync();
        return;
    }   
    
}
