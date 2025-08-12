using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Schools.UpdateSchool;

public class UpdateSchoolCommand(SchoolUpdateDto dto, int id ) : IRequest<SchoolResponseDto>
{
    public int Id { get; set; } = id;
    public SchoolUpdateDto SchoolUpdateDto { get; set; } = dto;
}

public class UpdateSchoolCommandHandler(IMapper mapper, ISchoolRepository repo) : IRequestHandler<UpdateSchoolCommand, SchoolResponseDto>
{
    public async Task<SchoolResponseDto> Handle(UpdateSchoolCommand request, CancellationToken cancellationToken)
    {
        var school = await repo.GetByIdAsync(request.Id);

        if (school == null)
            throw new Exception("School Not Found!");

        mapper.Map(request.SchoolUpdateDto, school);

        repo.Update(school);
        await repo.SaveChangesAsync();

        mapper.Map<SchoolResponseDto>(school);

        return mapper.Map<SchoolResponseDto>(school);
    }
}
