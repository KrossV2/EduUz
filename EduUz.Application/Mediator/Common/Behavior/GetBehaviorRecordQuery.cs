using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Common.Behavior
{
    public class GetBehaviorRecordQuery : IRequest<BehaviorRecordDto>
    {
        public int RecordId { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }

    public class GetBehaviorRecordQueryHandler : IRequestHandler<GetBehaviorRecordQuery, BehaviorRecordDto>
    {
        private readonly IBehaviorRecordRepository _behaviorRecordRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IParentRepository _parentRepository;

        public GetBehaviorRecordQueryHandler(
            IBehaviorRecordRepository behaviorRecordRepository,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            IParentRepository parentRepository)
        {
            _behaviorRecordRepository = behaviorRecordRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _parentRepository = parentRepository;
        }

        public async Task<BehaviorRecordDto> Handle(GetBehaviorRecordQuery request, CancellationToken cancellationToken)
        {
            var record = await _behaviorRecordRepository.GetByIdAsync(request.RecordId);
            if (record == null)
                throw new ArgumentException("Behavior record not found");

            // Check access based on user type
            bool hasAccess = false;

            switch (request.UserType)
            {
                case UserType.Teacher:
                    hasAccess = await _teacherRepository.HasAccessToStudentAsync(request.UserId, record.StudentId);
                    break;
                case UserType.Student:
                    hasAccess = record.StudentId == request.UserId;
                    break;
                case UserType.Parent:
                    var parentChildLink = await _parentRepository.GetParentStudentLinkAsync(request.UserId, record.StudentId);
                    hasAccess = parentChildLink != null;
                    break;
                case UserType.Director:
                case UserType.Admin:
                    hasAccess = true; // Directors and admins have access to all records
                    break;
            }

            if (!hasAccess)
                throw new UnauthorizedAccessException("User does not have access to this behavior record");

            return new BehaviorRecordDto
            {
                Id = record.Id,
                StudentId = record.StudentId,
                StudentName = record.Student?.FullName ?? "Unknown",
                TeacherId = record.TeacherId,
                TeacherName = record.Teacher?.FullName ?? "Unknown",
                Type = record.Type,
                Points = record.Points,
                Description = record.Description,
                Date = record.Date,
                Evidence = record.Evidence,
                CreatedAt = record.CreatedAt
            };
        }
    }

    public class BehaviorRecordDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public BehaviorType Type { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Evidence { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}