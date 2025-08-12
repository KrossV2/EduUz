using System.Text.RegularExpressions;
using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Sutudents.GetStudentsByClassId;

public class GetStudentsByClassIdQuery(int ClassId) : IRequest<List<Student>>
{
    public int ClassId { get; set; } = ClassId;
}


public class GetStudentByClassIdQueryHandler(EduUzDbContext context, IMapper mapper) : IRequestHandler<GetStudentsByClassIdQuery, List<Student>>
{
    public async Task<List<Student>> Handle(GetStudentsByClassIdQuery request, CancellationToken cancellationToken)
    {
        return context.Students
            .Where(s => s.ClassId == request.ClassId)
            .ToList();
    }
}
