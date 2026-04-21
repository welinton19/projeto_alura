using Microsoft.AspNetCore.Authorization;

namespace Projeto_Alura.Infrastructure.Auth;

public class RoleRequeriment : IAuthorizationRequirement
{
    public string Role { get; set; }
    public RoleRequeriment(string role)
    {
        Role = role;
    }
}
