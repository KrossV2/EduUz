using AutoMapper;
using EduUz.Application.Mediatr.Directors.Teachers.AddSubjectToTeacher;
using EduUz.Core.Dtos;
using EduUz.Core.Models;

namespace EduUz.Application.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // ================= USER =================
        CreateMap<User, UserDto>();
        CreateMap<User, UserResponseDto>();
        CreateMap<UserCreateDto, User>();
        CreateMap<UserUpdateDto, User>();

        // ================= REGION =================
        CreateMap<Region, RegionDto>();
        CreateMap<Region, RegionResponseDto>();
        CreateMap<RegionCreateDto, Region>();
        CreateMap<RegionUpdateDto, Region>();

        // ================= CITY =================
        CreateMap<City, CityDto>();
        CreateMap<City, CityResponseDto>();
        CreateMap<CityCreateDto, City>();
        CreateMap<CityUpdateDto, City>();

        // ================= SCHOOL =================
        CreateMap<School, SchoolDto>();
        CreateMap<School, SchoolResponseDto>();
        CreateMap<SchoolCreateDto, School>();
        CreateMap<SchoolUpdateDto, School>();

        // ================= CLASS =================
        CreateMap<Class, ClassDto>();
        CreateMap<Class, ClassResponseDto>();
        CreateMap<ClassCreateDto, Class>();
        CreateMap<ClassUpdateDto, Class>();

        // ================= STUDENT =================
        CreateMap<Student, StudentDto>();
        CreateMap<Student, StudentResponseDto>();
        CreateMap<StudentCreateDto, Student>();
        CreateMap<StudentUpdateDto, Student>();

        // ================= TEACHER =================
        CreateMap<Teacher, TeacherDto>();
        CreateMap<Teacher, TeacherResponseDto>();
        CreateMap<TeacherCreateDto, Teacher>()
            .ForMember(dest => dest.TeacherSubjects, opt => opt.MapFrom(src =>
                src.SubjectIds.Select(id => new TeacherSubject { SubjectId = id }).ToList()
            ));
        CreateMap<TeacherUpdateDto, Teacher>();

        // ================= SUBJECT =================
        CreateMap<Subject, SubjectDto>();
        CreateMap<Subject, SubjectResponseDto>();
        CreateMap<SubjectCreateDto, Subject>();
        CreateMap<SubjectUpdateDto, Subject>();

        // ================= TEACHER SUBJECT =================
        CreateMap<TeacherSubject, TeacherSubjectDto>();
        CreateMap<TeacherSubject, TeacherSubjectResponseDto>();
        CreateMap<TeacherSubjectCreateDto, TeacherSubject>();

        // ================= ATTENDANCE =================
        CreateMap<Attendance, AttendanceDto>();
        CreateMap<Attendance, AttendanceResponseDto>();
        CreateMap<AttendanceCreateDto, Attendance>();
        CreateMap<AttendanceUpdateDto, Attendance>();

        // ================= BEHAVIOR RECORD =================
        CreateMap<BehaviorRecord, BehaviorRecordDto>();
        CreateMap<BehaviorRecord, BehaviorRecordResponseDto>();
        CreateMap<BehaviorRecordCreateDto, BehaviorRecord>();
        CreateMap<BehaviorRecordUpdateDto, BehaviorRecord>();

        // ================= GRADE =================
        CreateMap<Grade, GradeDto>();
        CreateMap<Grade, GradeResponseDto>();
        CreateMap<GradeCreateDto, Grade>();
        CreateMap<GradeUpdateDto, Grade>();

        // ================= HOMEWORK =================
        CreateMap<Homework, HomeworkDto>();
        CreateMap<Homework, HomeworkResponseDto>();
        CreateMap<HomeworkCreateDto, Homework>();
        CreateMap<HomeworkUpdateDto, Homework>();

        // ================= LESSON SCHEDULE =================
        CreateMap<LessonSchedule, LessonScheduleDto>();
        CreateMap<LessonScheduleCreateDto, LessonSchedule>();
        CreateMap<LessonScheduleUpdateDto, LessonSchedule>();

        // ================= NOTIFICATION =================
        CreateMap<Notification, NotificationDto>();
        CreateMap<Notification, NotificationResponseDto>();
        CreateMap<NotificationCreateDto, Notification>();
        CreateMap<NotificationUpdateDto, Notification>();

        // ================= PARENT =================
        CreateMap<Parent, ParentDto>();
        CreateMap<Parent, ParentResponseDto>();
        CreateMap<ParentCreateDto, Parent>();
        CreateMap<ParentUpdateDto, Parent>();

        // ================= PARENT STUDENT =================
        CreateMap<ParentStudent, ParentStudentDto>();
        CreateMap<ParentStudentCreateDto, ParentStudent>();

        // ================= TIMETABLE =================
        CreateMap<Timetable, TimetableDto>();
        CreateMap<Timetable, TimetableResponseDto>();
        CreateMap<TimetableCreateDto, Timetable>();
        CreateMap<TimetableUpdateDto, Timetable>();

        // ================= DIRECTOR =================
        CreateMap<Director, DirectorDto>();
        CreateMap<DirectorCreateDto, Director>();
        CreateMap<DirectorUpdateDto, Director>();

        // ================= STATISTICS =================
        CreateMap<ClassStatistics, ClassStatisticsDto>();
        CreateMap<TeacherStatistics, TeacherStatisticsDto>();
        CreateMap<AttendanceStatistics, AttendanceStatisticsDto>();
    }
}
