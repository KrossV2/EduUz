namespace EduUz.Core.Dtos;

public record AuthResponseDto(string Token, string RefreshToken, DateTime Expires);