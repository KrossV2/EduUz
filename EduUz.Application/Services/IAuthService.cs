using EduUz.Application.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace EduUz.Application.Services;

public interface IAuthService
{
    string GetToken(string username);
}

public class AuthService(IOptions<JwtSettings> settings) : IAuthService
{
    private readonly IOptions<JwtSettings> _settings = settings;
    private readonly JwtSecurityTokenHandler _handler = new();

    public string GetToken(string username)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "cafe.uz",
            "cafe.uz",
            claims: [
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("user_id", "1")
            ],
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: credentials
        );

        return _handler.WriteToken(token);
    }
}
