using Projeto_Alura.Application.DTOs;
using Projeto_Alura.Application.Exceptions;
using Projeto_Alura.Application.Interfaces;
using Projeto_Alura.Domain.Entitis;
using Projeto_Alura.Domain.Interfaces;


namespace Projeto_Alura.Application.Services;

public class UsersService : IUsersServices
{
    private readonly IUserRepository _userRepository;

    public UsersService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Users> AddUsersAsync(CreateUsersDTO createUsersDTO)
    {

        if (createUsersDTO.Password != createUsersDTO.ConfirmPassword)
            throw new Exception("As senhas não conferem!");


        var emailExists = await _userRepository.ExistsByEmailAsync(createUsersDTO.Email);
        if (emailExists)
            throw new Exception("Email já cadastrado!");


        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUsersDTO.Password);


        var user = new Users
        {
            Name = createUsersDTO.Name,
            Email = createUsersDTO.Email,
            Password = hashedPassword,
            Role = createUsersDTO.Role

        };

        await _userRepository.AddUserAsync(user);

        return user;
    }

    public async Task DeleteUsersAsync(DeleteUsersDTO deleteUsersDTO)
    {
        await _userRepository.DeleteUserAsync(id: deleteUsersDTO.Id);

    }

    public async Task<List<Users>> GetAllAsync(GetAllUsersDTO allUsersDTO)
    {
        var allusers = await _userRepository.GetAllUsersAsync();
        var users = new List<Users>();
        foreach (var user in allusers)
        {
            users.Add(new Users
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            });
        }
        return users;
    }

    public async Task<Users> GetUsersById(GetIdUsersDTO idUserDTO)
    {
        var usersid = await _userRepository.GetUserByIdAsync(idUserDTO.Id);
        if (usersid == null)
            throw new NotFoundExceptions("Usuario", idUserDTO);
        return usersid;
    }

    public async Task<Users?> LoginAsync(string email, string password)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        if (user == null) return null;

        var isValid = BCrypt.Net.BCrypt.Verify(password, user.Password);
        if (!isValid) return null;

        return user;
    }

    public async Task<Users> UpdateUsersAsync(UpdateUsersDTO updateUsersDTO)
    {

        var user = await _userRepository.GetUserByIdAsync(updateUsersDTO.Id);
        if (user == null)
            throw new Exception("Usuário não encontrado!");



        user.Email = updateUsersDTO.Email;
        user.Password = updateUsersDTO.Password;
        user.ConfirmPassword = updateUsersDTO.ConfirmPassword;


        if (!string.IsNullOrEmpty(updateUsersDTO.Password))
        {
            if (updateUsersDTO.Password != updateUsersDTO.ConfirmPassword)
                throw new Exception("As senhas não conferem!");

            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUsersDTO.Password);
        }


        await _userRepository.UpdateUserAsync(user);

        return user;
    }
}
