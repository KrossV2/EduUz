using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Teachers.Students
{
    public class AddStudentCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public int ClassId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public AddStudentCommandHandler(
            IStudentRepository studentRepository,
            ITeacherRepository teacherRepository,
            IUserRepository userRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<int> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher is a class teacher for this class
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            var isClassTeacher = await _teacherRepository.IsClassTeacherAsync(request.TeacherId, request.ClassId);
            if (!isClassTeacher)
                throw new UnauthorizedAccessException("Teacher is not a class teacher for this class");

            // Check if email is already used
            if (!string.IsNullOrEmpty(request.Email))
            {
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUser != null)
                    throw new ArgumentException("Email is already in use");
            }

            // Check if username is already used
            var existingUsername = await _userRepository.GetByUsernameAsync(request.Username);
            if (existingUsername != null)
                throw new ArgumentException("Username is already in use");

            // Create user account
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                UserType = UserType.Student,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var userId = await _userRepository.AddAsync(user);

            // Create student
            var student = new Student
            {
                UserId = userId,
                ClassId = request.ClassId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = $"{request.FirstName} {request.LastName}",
                BirthDate = request.BirthDate,
                PhoneNumber = request.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            var studentId = await _studentRepository.AddAsync(student);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddStudent",
                Description = $"Added student {student.FullName} to class {request.ClassId}",
                CreatedAt = DateTime.UtcNow
            });

            return studentId;
        }
    }
}