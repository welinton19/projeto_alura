using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Domain.Entitis;

namespace Projeto_Alura.Application.Interfaces;

public interface IUsersServices
{
    Task<Users> AddUsersAsync(CreateUsersDTO createUsersDTO);
    Task<List<Users>> GetAllAsync(GetAllUsersDTO allUsersDTO);
    Task<Users> GetUsersById(GetIdUsersDTO idUserDTO);
    Task<Users> UpdateUsersAsync(UpdateUsersDTO updateUsersDTO);
    Task DeleteUsersAsync(DeleteUsersDTO deleteUsersDTO);
    Task<Users?> LoginAsync(string email, string password);
}
