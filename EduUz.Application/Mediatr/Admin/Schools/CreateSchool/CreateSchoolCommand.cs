using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Schools.CreateSchool;

public class CreateSchoolCommand(SchoolCreateDto dto) : IRequest<SchoolResponseDto>
{
    public SchoolCreateDto SchoolCreateDto { get; set; } = dto;
}



public class CreateSchoolCommandHandler(EduUzDbContext context, ISchoolRepository repo, IMapper mapper) : IRequestHandler<CreateSchoolCommand, SchoolResponseDto>
{
    public async Task<SchoolResponseDto> Handle(CreateSchoolCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var newSchool = mapper.Map<School>(request.SchoolCreateDto);

            await repo.AddAsync(newSchool);
            await repo.SaveChangesAsync();

            var response = mapper.Map<SchoolResponseDto>(newSchool);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating School", ex);
        }
    }
}