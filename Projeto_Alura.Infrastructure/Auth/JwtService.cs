using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projeto_Alura.Domain.Entitis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto_Alura.Infrastructure.Auth;

public class JwtService
{
    private readonly IConfiguration _config;

    public JwtService(IConfiguration config)
    {
        _config = config;
    }

    public (string Secret, string Issuer, string Audience, DateTime Expiration) GerarToken(Users users)
    {
        var secret = _config["Jwt:Secret"];
        var issuer = _config["Jwt:Issuer"];
        var audience = _config["Jwt:Audience"];
        var expiryMinutes = int.TryParse(_config["Jwt:ExpiryMinutes"], out var minutes) ? minutes : 60;
        var expiration = DateTime.UtcNow.AddMinutes(expiryMinutes);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim("id", users.Id.ToString()),
            new Claim("name", users.Name),
            new Claim("email", users.Email),
            new Claim("role", users.Role.ToString()),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: claims,
            expires: expiration,
            signingCredentials: creds
        );



        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return (tokenString, issuer, audience, expiration);

    }

    internal object GerarToken(bool usersAuthentication)
    {
        var token = new JwtSecurityToken();
        string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }
}

