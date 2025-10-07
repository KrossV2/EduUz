using Microsoft.AspNetCore.Http;

namespace EduUz.Core.Dtos;

public class DirectorCreateDto
{
    public int UserId { get; set; }
    public IFormFile Image { get; set; }
}