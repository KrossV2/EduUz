using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Application.Services;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Directors.CreateDirector;

public class CreateDirectorCommand(DirectorCreateDto dto) : IRequest<int>
{
    public DirectorCreateDto DirectorCreateDto { get; set; } = dto;
}

public class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand, int>
{
    private readonly IDirectorRepository _repo;
    private readonly IMapper _mapper;
    private readonly EduUzDbContext _context;
    private readonly IFileService fileService;

    public CreateDirectorCommandHandler(IDirectorRepository repo, IMapper mapper, EduUzDbContext context , IFileService fileservice)
    {
        _repo = repo;
        _mapper = mapper;
        _context = context;
        fileService = fileservice;
    }

    public async Task<int> Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            // User mavjudligini tekshirish
            var user = await _context.Users.FindAsync(request.DirectorCreateDto.UserId);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            if (request.DirectorCreateDto.Image != null)
            {
                user.ImagePath = await fileService.SaveFileAsync(request.DirectorCreateDto.Image , "users");
            }

            var director = _mapper.Map<Director>(request.DirectorCreateDto);

            // SchoolId null bo'lishini ta'minlash
            director.SchoolId = null;

            await _repo.AddAsync(director);
            await _repo.SaveChangesAsync();

            return director.Id;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Director", ex);
        }
    }
}
