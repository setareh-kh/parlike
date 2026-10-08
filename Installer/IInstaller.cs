namespace ParlikeWebApi.Installer;
public interface IInstaller
{
    void InstallServices(IConfiguration configuration , IServiceCollection services);
}