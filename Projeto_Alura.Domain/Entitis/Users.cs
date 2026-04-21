using Projeto_Alura.Domain.Enum;

namespace Projeto_Alura.Domain.Entitis;

public class Users
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public Roles Role { get; set; }


    public Users()
    {
    }

    public Users(long id, string name, string email, string password, string confirmPassword, Roles role)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        Role = role;
    }
}
