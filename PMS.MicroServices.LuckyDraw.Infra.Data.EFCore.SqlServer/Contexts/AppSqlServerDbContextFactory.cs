using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Contexts;

public class AppSqlServerDbContextFactory
    : IDesignTimeDbContextFactory<AppSqlServerDbContext>
{
    #region Methods
    public AppSqlServerDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                              .AddJsonFile(CoreInfraCrossCuttingConstants.AppSettingsDefaultJsonFile)
                                                              .Build();
        string? connectionString = config.GetConnectionString(EFCoreSqlServerConstants.ConnectionStringName);
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException($"Could not find connection string named '{EFCoreSqlServerConstants.ConnectionStringName}'");
        return new AppSqlServerDbContext(config);
    }
    #endregion Methods
}
