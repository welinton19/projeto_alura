using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllUsersAsync();
    Task<Users> GetUserByIdAsync(long id);
    Task AddUserAsync(Users user);
    Task UpdateUserAsync(Users user);
    Task DeleteUserAsync(long id);
}
