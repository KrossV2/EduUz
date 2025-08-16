using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using EduUz.Application.Repositories;
using EduUz.Application.Services;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Common.FileUpload
{
    public class UploadFileCommand : IRequest<FileUploadResult>
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public byte[] FileContent { get; set; }
        public string Description { get; set; }
    }

    public class FileUploadResult
    {
        public int FileId { get; set; }
        public string FileUrl { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
    }

    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, FileUploadResult>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IFileStorageService _fileStorageService;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public UploadFileCommandHandler(
            IFileRepository fileRepository,
            IFileStorageService fileStorageService,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _fileRepository = fileRepository;
            _fileStorageService = fileStorageService;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<FileUploadResult> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            // Validate file size (max 10MB)
            if (request.FileSize > 10 * 1024 * 1024)
                throw new ArgumentException("File size cannot exceed 10MB");

            // Validate file type
            var allowedTypes = new[] { "pdf", "doc", "docx", "jpg", "jpeg", "png", "mp4", "avi", "mov" };
            var fileExtension = Path.GetExtension(request.FileName).ToLowerInvariant().TrimStart('.');
            if (!allowedTypes.Contains(fileExtension))
                throw new ArgumentException("File type not allowed");

            // Generate unique filename
            var uniqueFileName = $"{Guid.NewGuid()}_{request.FileName}";

            // Upload file to storage
            var fileUrl = await _fileStorageService.UploadFileAsync(uniqueFileName, request.FileContent, request.FileType);

            // Save file record to database
            var file = new FileRecord
            {
                UserId = request.UserId,
                UserType = request.UserType,
                FileName = request.FileName,
                FileUrl = fileUrl,
                FileType = request.FileType,
                FileSize = request.FileSize,
                Description = request.Description,
                CreatedAt = DateTime.UtcNow
            };

            var fileId = await _fileRepository.AddAsync(file);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.UserId,
                UserType = request.UserType,
                Action = "UploadFile",
                Description = $"Uploaded file: {request.FileName}",
                CreatedAt = DateTime.UtcNow
            });

            return new FileUploadResult
            {
                FileId = fileId,
                FileUrl = fileUrl,
                FileName = request.FileName,
                FileType = request.FileType,
                FileSize = request.FileSize
            };
        }
    }
}