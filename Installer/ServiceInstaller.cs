using ParlikeWebApi.Repositories;
using ParlikeWebApi.Repositories.Repository;

namespace ParlikeWebApi.Installer;

public class ServiceInstaller : IInstaller
{
    public void InstallServices(IConfiguration configuration, IServiceCollection services)
    {
        //install Irepositor and repository as services
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

    }
}