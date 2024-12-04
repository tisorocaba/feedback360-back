using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.Data.EFCore.UoW;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, EFCoreUnitOfWork>();
    }
}
