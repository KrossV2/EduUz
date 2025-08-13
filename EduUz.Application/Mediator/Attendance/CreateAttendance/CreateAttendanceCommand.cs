using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Attendance.CreateAttendance;

public class CreateAttendanceCommand(AttendanceCreateDto dto) : IRequest<AttendanceResponseDto>
{
    public AttendanceCreateDto AttendanceCreateDto { get; set; } = dto;
}

public class CreateAttendanceCommandHandler(IAttendanceRepository repo, IMapper mapper) : IRequestHandler<CreateAttendanceCommand, AttendanceResponseDto>
{
    public async Task<AttendanceResponseDto> Handle(CreateAttendanceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newAttendance = mapper.Map<Core.Models.Attendance>(request.AttendanceCreateDto);
            
            await repo.AddAsync(newAttendance);
            await repo.SaveChangesAsync();

            var response = mapper.Map<AttendanceResponseDto>(newAttendance);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating attendance", ex);
        }
    }
}