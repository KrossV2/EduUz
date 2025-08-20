using AutoMapper;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Teacher.Attendances.UpdateAttendance;

public record UpdateAttendanceCommand(int Id, AttendanceUpdateDto Dto) : IRequest<AttendanceDto>;

public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, AttendanceDto>
{
    private readonly EduUzDbContext _context;
    private readonly IMapper _mapper;

    public UpdateAttendanceCommandHandler(EduUzDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AttendanceDto> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Attendances.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null)
            throw new KeyNotFoundException("Attendance not found");

        entity.Status = request.Dto.Status;
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<AttendanceDto>(entity);
    }
}