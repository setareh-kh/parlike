using Microsoft.EntityFrameworkCore;
using ParlikeWebApi.Models;

namespace ParlikeWebApi.Installer;

public class DataInstaller : IInstaller
{
    public void InstallServices(IConfiguration configuration, IServiceCollection services)
    {
        var myConnection = configuration.GetConnectionString("MySqlConnection") ?? throw new InvalidOperationException(
        "Connection string 'MySqlConnection' was not found.");
        services.AddDbContext<SqlContext>(opts => opts.UseMySQL(myConnection));
    }
}