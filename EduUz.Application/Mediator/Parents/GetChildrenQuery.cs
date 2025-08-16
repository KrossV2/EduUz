using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Parents
{
    public class GetChildrenQuery : IRequest<List<ChildDto>>
    {
        public int ParentId { get; set; }
    }

    public class GetChildrenQueryHandler : IRequestHandler<GetChildrenQuery, List<ChildDto>>
    {
        private readonly IParentRepository _parentRepository;
        private readonly IStudentRepository _studentRepository;

        public GetChildrenQueryHandler(IParentRepository parentRepository, IStudentRepository studentRepository)
        {
            _parentRepository = parentRepository;
            _studentRepository = studentRepository;
        }

        public async Task<List<ChildDto>> Handle(GetChildrenQuery request, CancellationToken cancellationToken)
        {
            // Check if parent exists
            var parent = await _parentRepository.GetByIdAsync(request.ParentId);
            if (parent == null)
                throw new UnauthorizedAccessException("Parent not found");

            var children = await _parentRepository.GetChildrenByParentIdAsync(request.ParentId);

            return children.Select(c => new ChildDto
            {
                Id = c.StudentId,
                FirstName = c.Student.FirstName,
                LastName = c.Student.LastName,
                FullName = c.Student.FullName,
                ClassId = c.Student.ClassId,
                ClassName = c.Student.Class.Name,
                SchoolName = c.Student.Class.School.Name,
                BirthDate = c.Student.BirthDate,
                PhoneNumber = c.Student.PhoneNumber
            }).ToList();
        }
    }

    public class ChildDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public string SchoolName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}