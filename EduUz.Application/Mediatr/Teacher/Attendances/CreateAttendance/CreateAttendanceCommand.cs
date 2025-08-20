using AutoMapper;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using System;

namespace EduUz.Application.Mediatr.Teacher.Attendances.CreateAttendance;

public record CreateAttendanceCommand(AttendanceCreateDto Dto) : IRequest<AttendanceDto>;

public class CreateAttendanceCommandHandler : IRequestHandler<CreateAttendanceCommand, AttendanceDto>
{
    private readonly EduUzDbContext _context;
    private readonly IMapper _mapper;

    public CreateAttendanceCommandHandler(EduUzDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AttendanceDto> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<Attendance>(request.Dto);
        _context.Attendances.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return _mapper.Map<AttendanceDto>(entity);
    }
}
