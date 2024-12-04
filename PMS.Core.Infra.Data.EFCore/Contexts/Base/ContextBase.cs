using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.EFCore.Constants;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;

namespace PMS.Core.Infra.Data.EFCore.Contexts.Base;

public abstract class ContextBase
    : DbContext, IDbContext
{
    #region Constructors
    public ContextBase(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    #endregion Constructors

    #region Fields
    readonly IConfiguration _configuration;
    #endregion Fields

    #region Methods
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        bool useLazyLoading = TypeUtility.ConvertToBoolean(this._configuration.GetSection(CoreInfraDataEFCoreConstants.KeyOfAppSettingsEFCoreUseLazyLoading)?.Value);
        bool useQueryNoTrackingBehavior = TypeUtility.ConvertToBoolean(this._configuration.GetSection(CoreInfraDataEFCoreConstants.KeyOfAppSettingsEFCoreUseQueryNoTrackingBehavior)?.Value);

        if (useQueryNoTrackingBehavior)
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        if ((!useQueryNoTrackingBehavior) && useLazyLoading)
            optionsBuilder.UseLazyLoadingProxies();

        ConnectionString = ConfigureConnectionString();
        Configure(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        this.ApplyMappings(modelBuilder);

        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
            relationship.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }

    public abstract void ApplyMappings(ModelBuilder modelBuilder);
    public abstract void Configure(DbContextOptionsBuilder optionsBuilder);
    public abstract string ConfigureConnectionString();
    #endregion Methods

    #region Properties
    public virtual string? ConnectionString { get; protected set; }
    #endregion Properties
}
