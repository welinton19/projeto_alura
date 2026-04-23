using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Projeto_Alura.Infrastructure.Auth;

public class JwtSettings
{
    public string SecretKey { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool Encrypt { get; set; }
    public int ExpirationInMinutes { get; set; } =60;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}
