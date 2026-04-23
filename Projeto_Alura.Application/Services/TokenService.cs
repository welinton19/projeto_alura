using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Projeto_Alura.Application.Interfaces;
using System.Security.Claims;
using Projeto_Alura.Infrastructure.Auth;

namespace Projeto_Alura.Application.Services;

public class TokenService : ITokenServices
{
    
    private readonly JwtSettings _jwtSettings;

    public TokenService(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public Task<string> GerartToken(string email, string role)
    {
        var claim = new[]
        {
            new Claim(ClaimTypes.Email, email),
            new Claim(ClaimTypes.Role, role)
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claim,
            expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationInMinutes),
            signingCredentials: creds
        );

        var tokenHandler = new JwtSecurityTokenHandler();
        return Task.FromResult(tokenHandler.WriteToken(token));
    }
}
