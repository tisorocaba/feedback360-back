using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PMS.Core.Infra.Data.EFCore.Contexts.Base;

namespace PMS.Core.Infra.Data.EFCore.SqlServer.Contexts;

public abstract class SqlServerContext
    : ContextBase
{
    #region Constructors
    public SqlServerContext(IConfiguration configuration)
        : base(configuration)
    {

    }
    #endregion Constructors

    #region Methods
    public override void Configure(DbContextOptionsBuilder optionsBuilder)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter((category, level) => (
                (category == DbLoggerCategory.Database.Command.Name) && (level == LogLevel.Information))
            );
        });

        optionsBuilder.UseSqlServer(ConnectionString, options =>
        {
            options.EnableRetryOnFailure(3);
        });

        optionsBuilder.UseLoggerFactory(loggerFactory);
        optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
    }
    #endregion Methods
}
