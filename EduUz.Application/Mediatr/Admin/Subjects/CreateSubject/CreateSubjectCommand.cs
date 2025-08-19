using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Subjects.CreateSubject;

public class CreateSubjectCommand(SubjectCreateDto dto) : IRequest<SubjectResponseDto>
{
    public SubjectCreateDto SubjectCreateDto { get; set; } = dto;
}

public class CreateSubjectCommandHandler(ISubjectRepository repo, IMapper mapper) : IRequestHandler<CreateSubjectCommand, SubjectResponseDto>
{
    public async Task<SubjectResponseDto> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var subject = mapper.Map<Subject>(request.SubjectCreateDto);

            await repo.AddAsync(subject);
            await repo.SaveChangesAsync();

            var response = mapper.Map<SubjectResponseDto>(subject);

            return response;
        }
        catch (AutoMapperMappingException ex)
        {
            throw new ApplicationException("Mapping error occurred", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error creating Subject", ex);
        }
    }
}
