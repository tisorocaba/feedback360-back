using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.EFCore.Constants;
using PMS.Core.Infra.Data.EFCore.SqlServer.Models;

namespace PMS.Core.Infra.Data.EFCore.SqlServer.Contexts;

public abstract class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    #region Constructors
    public ApplicationDbContext(IConfiguration configuration)
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
        bool UseQueryNoTrackingBehavior = TypeUtility.ConvertToBoolean(this._configuration.GetSection(CoreInfraDataEFCoreConstants.KeyOfAppSettingsEFCoreUseQueryNoTrackingBehavior)?.Value);

        if (UseQueryNoTrackingBehavior)
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.ApplyConfiguration(new ApplicationRoleEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new ApplicationUserEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new RoleEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new RoleClaimEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new UserEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new UserRoleEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new UserClaimEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new UserLoginEFCoreSqlServerDataModelMap());
        //modelBuilder.ApplyConfiguration(new UserTokenEFCoreSqlServerDataModelMap());

        var relationships = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
        foreach (var relationship in relationships)
            relationship.DeleteBehavior = DeleteBehavior.Restrict;

        base.OnModelCreating(modelBuilder);
    }
    #endregion Methods
}
