namespace EduUz.Core.Dtos;

public record FileUploadDto(string FileName, string ContentType, byte[] Content);
