namespace EduUz.Core.Dtos;

public class LoginResponseDto
{
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public string Role { get; set; }
    public string FullName { get; set; }
}
