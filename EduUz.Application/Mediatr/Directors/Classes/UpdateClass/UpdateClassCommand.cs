using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Directors.Classes.UpdateClass;

public class UpdateClassCommand(ClassUpdateDto dto , int id) : IRequest<ClassResponseDto>
{
    public int Id { get; set; } = id;
    public ClassUpdateDto Class { get; set; } = dto; 
}


public class UpdateClassCommandHandler(IClassRepository repo, IMapper mapper) : IRequestHandler<UpdateClassCommand, ClassResponseDto>
{
    public async Task<ClassResponseDto> Handle(UpdateClassCommand request, CancellationToken cancellationToken)
    {
        var newClass = await repo.GetByIdAsync(request.Id);

        if (newClass == null)
            throw new Exception("Class Not Found!");

        mapper.Map(request.Class, newClass);

        repo.Update(newClass);
        await repo.SaveChangesAsync();

        return mapper.Map<ClassResponseDto>(newClass);
    }
}
