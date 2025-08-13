using EduUz.Application.AutoMapper;
using EduUz.Application.Repositories;
using EduUz.Application.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using System.Reflection;

namespace EduUz.Application.DiContainer;

public static class DiContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAttendanceRepository, AttendanceRepository>();
        services.AddScoped<IBehaviorRecordRepository, BehaviorRecordRepository>();
        services.AddScoped<ICityRepository, CityRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<IHomeworkRepository, HomeworkRepository>();
        services.AddScoped<ILessonScheduleRepository, LessonScheduleRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IParentRepository, ParentRepository>();
        services.AddScoped<IRegionRepository, RegionRepository>();
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<ISubjectRepository, SubjectRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<ITimetableRepository, TimetableRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ITeacherSubjectRepository, TeacherSubjectRepository>();
        services.AddScoped<IParentStudentRepository, ParentStudentRepository>();
        services.AddScoped<IDirectorRepository, DirectorRepository>();
        services.AddScoped<IStatisticsRepository, StatisticsRepository>();


        services.AddAutoMapper(typeof(MappingProfile));

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}
