using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PMS.MicroServices.LuckyDraw.Service.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        Application.IoC.Bootstrapper.ConfigureServices(services);
        Domain.IoC.Bootstrapper.ConfigureServices(services);
        Infra.Data.EFCore.SqlServer.IoC.Bootstrapper.ConfigureServices(services);
        Infra.Data.MongoDB.IoC.Bootstrapper.ConfigureServices(services, configuration);
    }
}
