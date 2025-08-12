using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediator.Subjects.UpdateSubject;

public class UpdateSubjectCommand(SubjectUpdateDto dto , int id) : IRequest<SubjectResponseDto>
{
    public int Id { get; set; } = id;
    public SubjectUpdateDto SubjectUpdateDto { get; set; } = dto;
}


public class UpdateSubjectCommandHanler(ISubjectRepository repo, IMapper mapper) : IRequestHandler<UpdateSubjectCommand, SubjectResponseDto>
{
    public async Task<SubjectResponseDto> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
    {
        var subject = await repo.GetByIdAsync(request.Id);

        if (subject == null)
            throw new Exception("Subject Not Found!");

        mapper.Map(request.SubjectUpdateDto, subject);

        repo.Update(subject);
        await repo.SaveChangesAsync();

        return mapper.Map<SubjectResponseDto>(subject);
    }
}
