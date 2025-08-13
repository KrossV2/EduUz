using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Attendance.UpdateAttendance;

public class UpdateAttendanceCommand(int id, AttendanceUpdateDto dto) : IRequest<AttendanceResponseDto>
{
    public int Id { get; set; } = id;
    public AttendanceUpdateDto AttendanceUpdateDto { get; set; } = dto;
}

public class UpdateAttendanceCommandHandler(IAttendanceRepository repo, IMapper mapper) : IRequestHandler<UpdateAttendanceCommand, AttendanceResponseDto>
{
    public async Task<AttendanceResponseDto> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var existingAttendance = await repo.GetByIdAsync(request.Id);
            if (existingAttendance == null)
            {
                throw new ApplicationException("Attendance record not found");
            }

            mapper.Map(request.AttendanceUpdateDto, existingAttendance);
            
            repo.Update(existingAttendance);
            await repo.SaveChangesAsync();

            var response = mapper.Map<AttendanceResponseDto>(existingAttendance);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error updating attendance", ex);
        }
    }
}