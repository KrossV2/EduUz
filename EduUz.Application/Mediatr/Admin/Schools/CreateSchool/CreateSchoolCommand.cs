using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Admin.Schools.CreateSchool;

public class CreateSchoolCommand(SchoolCreateDto dto) : IRequest<SchoolResponseDto>
{
    public SchoolCreateDto SchoolCreateDto { get; set; } = dto;
}



public class CreateSchoolCommandHandler : IRequestHandler<CreateSchoolCommand, SchoolResponseDto>
{
    private readonly EduUzDbContext _context;
    private readonly ISchoolRepository _repo;
    private readonly IMapper _mapper;

    public CreateSchoolCommandHandler(EduUzDbContext context, ISchoolRepository repo, IMapper mapper)
    {
        _context = context;
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<SchoolResponseDto> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
    {
        using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            // Director mavjudligini tekshirish
            var director = await _context.Directors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.Id == request.SchoolCreateDto.DirectorId, cancellationToken);

            if (director == null)
            {
                throw new ApplicationException("Director not found");
            }

            // City mavjudligini tekshirish
            var city = await _context.Cities
                .Include(c => c.Region)
                .FirstOrDefaultAsync(c => c.Id == request.SchoolCreateDto.CityId, cancellationToken);

            if (city == null)
            {
                throw new ApplicationException("City not found");
            }

            // Yangi school yaratish
            var newSchool = new School
            {
                Name = request.SchoolCreateDto.Name,
                CityId = request.SchoolCreateDto.CityId,
                DirectorId = request.SchoolCreateDto.DirectorId
            };

            await _repo.AddAsync(newSchool);
            await _repo.SaveChangesAsync();

            // Directorning SchoolId sini yangilash
            director.SchoolId = newSchool.Id;
            _context.Directors.Update(director);
            await _context.SaveChangesAsync(cancellationToken);

            // Transactionni commit qilish
            await transaction.CommitAsync(cancellationToken);

            // Response tayyorlash
            var response = new SchoolResponseDto
            {
                Id = newSchool.Id,
                Name = newSchool.Name,
                CityName = city.Name,
                RegionName = city.Region.Name,
                DirectorName = $"{director.User.FirstName} {director.User.LastName}",
            };

            return response;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);

            if (ex is AutoMapperMappingException)
            {
                throw new ApplicationException("Mapping error occurred", ex);
            }

            throw new ApplicationException("Error creating School", ex);
        }
    }
}