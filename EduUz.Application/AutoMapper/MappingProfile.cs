using AutoMapper;
using EduUz.Core.Dtos;
using EduUz.Core.Models;

namespace EduUz.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User Mappings
        CreateMap<User, UserDto>();
        CreateMap<UserCreateDto, User>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId))
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId));
        CreateMap<UserUpdateDto, User>();

        // Region Mappings
        CreateMap<Region, RegionDto>();
        CreateMap<RegionCreateDto, Region>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        CreateMap<RegionUpdateDto, Region>();

        // City Mappings
        CreateMap<City, CityDto>();
        CreateMap<CityCreateDto, City>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.RegionId, opt => opt.MapFrom(src => src.RegionId));
        CreateMap<CityUpdateDto, City>();

        // School Mappings
        CreateMap<School, SchoolDto>();
        CreateMap<SchoolCreateDto, School>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId));
        CreateMap<SchoolUpdateDto, School>();

        // Class Mappings
        CreateMap<Class, ClassDto>();
        CreateMap<ClassCreateDto, Class>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade))
            .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section))
            .ForMember(dest => dest.Shift, opt => opt.MapFrom(src => src.Shift))
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId));
        CreateMap<ClassUpdateDto, Class>();

        // Student Mappings
        CreateMap<Student, StudentDto>();
        CreateMap<StudentCreateDto, Student>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId));
        CreateMap<StudentUpdateDto, Student>();

        // Teacher Mappings
        CreateMap<Teacher, TeacherDto>();
        CreateMap<TeacherCreateDto, Teacher>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.SchoolId, opt => opt.MapFrom(src => src.SchoolId))
            .ForMember(dest => dest.IsClassTeacher, opt => opt.MapFrom(src => src.IsClassTeacher));
        CreateMap<TeacherUpdateDto, Teacher>();

        // Subject Mappings
        CreateMap<Subject, SubjectDto>();
        CreateMap<SubjectCreateDto, Subject>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        CreateMap<SubjectUpdateDto, Subject>();

        // TeacherSubject Mappings
        CreateMap<TeacherSubject, TeacherSubjectDto>();
        CreateMap<TeacherSubjectCreateDto, TeacherSubject>();

        // Attendance Mappings
        CreateMap<Attendance, AttendanceDto>();
        CreateMap<AttendanceCreateDto, Attendance>()
            .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
            .ForMember(dest => dest.Notes, opt => opt.MapFrom(src => src.Notes));
        CreateMap<AttendanceUpdateDto, Attendance>();

        // BehaviorRecord Mappings
        CreateMap<BehaviorRecord, BehaviorRecordDto>();
        CreateMap<BehaviorRecordCreateDto, BehaviorRecord>();
        CreateMap<BehaviorRecordUpdateDto, BehaviorRecord>();

        // Grade Mappings
        CreateMap<Grade, GradeDto>();
        CreateMap<GradeCreateDto, Grade>();
        CreateMap<GradeUpdateDto, Grade>();

        // Homework Mappings
        CreateMap<Homework, HomeworkDto>();
        CreateMap<HomeworkCreateDto, Homework>();
        CreateMap<HomeworkUpdateDto, Homework>();

        // LessonSchedule Mappings
        CreateMap<LessonSchedule, LessonScheduleDto>();
        CreateMap<LessonScheduleCreateDto, LessonSchedule>();
        CreateMap<LessonScheduleUpdateDto, LessonSchedule>();

        // Notification Mappings
        CreateMap<Notification, NotificationDto>();
        CreateMap<NotificationCreateDto, Notification>();
        CreateMap<NotificationUpdateDto, Notification>();

        // Parent Mappings
        CreateMap<Parent, ParentDto>();
        CreateMap<ParentCreateDto, Parent>();
        CreateMap<ParentUpdateDto, Parent>();

        // ParentStudent Mappings
        CreateMap<ParentStudent, ParentStudentDto>();
        CreateMap<ParentStudentCreateDto, ParentStudent>();

        // Timetable Mappings
        CreateMap<Timetable, TimetableDto>();
        CreateMap<TimetableCreateDto, Timetable>();
        CreateMap<TimetableUpdateDto, Timetable>();
        
        // Director Mappings
        CreateMap<Director, DirectorCreateDto>();
        CreateMap<DirectorCreateDto, Director>();
        CreateMap<DirectorUpdateDto, Director>();

        // Statistics Mappings (if models exist)
        // CreateMap<ClassStatistics, ClassStatisticsDto>();
        // CreateMap<TeacherStatistics, TeacherStatisticsDto>();
        // CreateMap<AttendanceStatistics, AttendanceStatisticsDto>();
    }
}

