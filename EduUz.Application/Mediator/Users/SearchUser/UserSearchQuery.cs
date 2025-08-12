using AutoMapper;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Users.SearchUser;

public record UserSearchQuery(
    string? SearchTerm,
    int? RoleId,
    int? SchoolId) : IRequest<List<UserDto>>;

public class UserSearchQueryHandler : IRequestHandler<UserSearchQuery, List<UserDto>>
{
    private readonly EduUzDbContext _context;
    private readonly IMapper _mapper;

    public UserSearchQueryHandler(EduUzDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserDto>> Handle(UserSearchQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Users
            .Include(u => u.Role)
            .Include(u => u.School)
            .AsQueryable();

        // Qidiruv bo'limi
        if (!string.IsNullOrEmpty(request.SearchTerm))
        {
            query = query.Where(u =>
                u.FirstName.Contains(request.SearchTerm) ||
                u.LastName.Contains(request.SearchTerm) ||
                u.Email.Contains(request.SearchTerm) ||
                u.Username.Contains(request.SearchTerm));
        }

        // Role bo'yicha filtr
        if (request.RoleId.HasValue)
        {
            query = query.Where(u => u.RoleId == request.RoleId.Value);
        }

        // Maktab bo'yicha filtr
        if (request.SchoolId.HasValue)
        {
            query = query.Where(u => u.SchoolId == request.SchoolId.Value);
        }

        // Natijalarni olish va DTO ga map qilish
        var users = await query
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToListAsync(cancellationToken);

        return _mapper.Map<List<UserDto>>(users);
    }
}