
namespace EduUz.Core.Dtos;

public class SignInResponseDto
{
    public int Id { get; set; }
    public string AccessToken { get; set; }

    public string RefreshToken { get; set; }

    public int ExpiresIn { get; set; }
}