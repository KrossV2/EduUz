using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Teachers.Students
{
    public class LinkParentToStudentCommand : IRequest<bool>
    {
        public int TeacherId { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }
    }

    public class LinkParentToStudentCommandHandler : IRequestHandler<LinkParentToStudentCommand, bool>
    {
        private readonly IParentRepository _parentRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public LinkParentToStudentCommandHandler(
            IParentRepository parentRepository,
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _parentRepository = parentRepository;
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<bool> Handle(LinkParentToStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher exists
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            // Check if parent exists
            var parent = await _parentRepository.GetByIdAsync(request.ParentId);
            if (parent == null)
                throw new ArgumentException("Parent not found");

            // Check if student exists
            var student = await _studentRepository.GetByIdAsync(request.StudentId);
            if (student == null)
                throw new ArgumentException("Student not found");

            // Check if teacher has access to this student (is class teacher)
            var isClassTeacher = await _teacherRepository.IsClassTeacherForStudentAsync(request.TeacherId, request.StudentId);
            if (!isClassTeacher)
                throw new UnauthorizedAccessException("Teacher does not have access to this student");

            // Check if link already exists
            var existingLink = await _parentRepository.GetParentStudentLinkAsync(request.ParentId, request.StudentId);
            if (existingLink != null)
                throw new ArgumentException("Parent is already linked to this student");

            // Create parent-student link
            var parentStudentLink = new ParentStudentLink
            {
                ParentId = request.ParentId,
                StudentId = request.StudentId,
                CreatedAt = DateTime.UtcNow
            };

            await _parentRepository.AddParentStudentLinkAsync(parentStudentLink);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "LinkParentToStudent",
                Description = $"Linked parent {parent.FullName} to student {student.FullName}",
                CreatedAt = DateTime.UtcNow
            });

            return true;
        }
    }
}