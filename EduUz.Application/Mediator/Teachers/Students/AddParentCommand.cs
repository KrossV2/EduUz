using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Teachers.Students
{
    public class AddParentCommand : IRequest<int>
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Relationship { get; set; } // Father, Mother, Guardian
    }

    public class AddParentCommandHandler : IRequestHandler<AddParentCommand, int>
    {
        private readonly IParentRepository _parentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUserRepository _userRepository;
        private readonly IActivityHistoryRepository _activityHistoryRepository;

        public AddParentCommandHandler(
            IParentRepository parentRepository,
            ITeacherRepository teacherRepository,
            IUserRepository userRepository,
            IActivityHistoryRepository activityHistoryRepository)
        {
            _parentRepository = parentRepository;
            _teacherRepository = teacherRepository;
            _userRepository = userRepository;
            _activityHistoryRepository = activityHistoryRepository;
        }

        public async Task<int> Handle(AddParentCommand request, CancellationToken cancellationToken)
        {
            // Check if teacher exists
            var teacher = await _teacherRepository.GetByIdAsync(request.TeacherId);
            if (teacher == null)
                throw new UnauthorizedAccessException("Teacher not found");

            // Check if email is already used
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new ArgumentException("Email is already in use");

            // Create user account
            var user = new User
            {
                Username = request.Email, // Use email as username for parents
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(GenerateRandomPassword()), // Generate random password
                UserType = UserType.Parent,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            var userId = await _userRepository.AddAsync(user);

            // Create parent
            var parent = new Parent
            {
                UserId = userId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                FullName = $"{request.FirstName} {request.LastName}",
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Relationship = request.Relationship,
                CreatedAt = DateTime.UtcNow
            };

            var parentId = await _parentRepository.AddAsync(parent);

            // Log activity
            await _activityHistoryRepository.AddAsync(new ActivityHistory
            {
                UserId = request.TeacherId,
                UserType = UserType.Teacher,
                Action = "AddParent",
                Description = $"Added parent {parent.FullName} with email {request.Email}",
                CreatedAt = DateTime.UtcNow
            });

            return parentId;
        }

        private string GenerateRandomPassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}