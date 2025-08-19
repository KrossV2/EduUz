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
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        // Region Mappings
        CreateMap<Region, RegionDto>();
        CreateMap<RegionCreateDto, Region>();
        CreateMap<RegionUpdateDto, Region>();

        // City Mappings
        CreateMap<City, CityDto>();
        CreateMap<CityCreateDto, City>();
        CreateMap<CityUpdateDto, City>();

        // School Mappings
        CreateMap<School, SchoolDto>();
        CreateMap<SchoolCreateDto, School>();
        CreateMap<SchoolUpdateDto, School>();

        // Class Mappings
        CreateMap<Class, ClassDto>();
        CreateMap<ClassCreateDto, Class>();
        CreateMap<ClassUpdateDto, Class>();

        // Student Mappings
        CreateMap<Student, StudentDto>();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();

        // Teacher Mappings
        CreateMap<Teacher, TeacherDto>();
        CreateMap<TeacherCreateDto, Teacher>()
    .ForMember(dest => dest.TeacherSubjects, opt => opt.MapFrom(src =>
        src.SubjectIds.Select(id => new TeacherSubject { SubjectId = id }).ToList()
    ));
        CreateMap<TeacherUpdateDto, Teacher>();

        // Subject Mappings
        CreateMap<Subject, SubjectDto>();
        CreateMap<SubjectCreateDto, Subject>();
        CreateMap<SubjectUpdateDto, Subject>();

        // TeacherSubject Mappings
        CreateMap<TeacherSubject, TeacherSubjectDto>();
        CreateMap<TeacherSubjectCreateDto, TeacherSubject>();

        // Attendance Mappings
        CreateMap<Attendance, AttendanceDto>();
        CreateMap<AttendanceCreateDto, Attendance>();
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
        CreateMap<Director, DirectorDto>();
        CreateMap<DirectorCreateDto, Director>();
        CreateMap<DirectorUpdateDto, Director>();

        // Statistics
        CreateMap<ClassStatistics, ClassStatisticsDto>();
        CreateMap<TeacherStatistics, TeacherStatisticsDto>();
        CreateMap<AttendanceStatistics, AttendanceStatisticsDto>();
    }
}

