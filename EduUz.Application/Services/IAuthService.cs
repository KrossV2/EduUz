using EduUz.Application.Settings;
using EduUz.Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EduUz.Application.Services;

public interface IAuthService
{
    string GetToken(User username);
}

public class AuthService(IOptions<JwtSettings> settings) : IAuthService
{
    private readonly IOptions<JwtSettings> _settings = settings;
    private readonly JwtSecurityTokenHandler _handler = new();

    public string GetToken(User user)
    {
        var claims = new List<Claim>
        {
        new Claim("user_id", user.Id.ToString()),
        new Claim("email", user.Email),
        new Claim("first_name", user.FirstName),
        new Claim("last_name", user.LastName),
        new Claim("username", user.Username),
        new Claim("role", user.Role.Name),
new Claim("school_name", user.School?.Name ?? string.Empty),
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Value.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            "cafe.uz",
            "cafe.uz",
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: credentials
        );

        return _handler.WriteToken(token);
    }
}
