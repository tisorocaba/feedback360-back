using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.Data.EFCore.SqlServer.Constants;
using PMS.Core.Infra.Data.EFCore.SqlServer.Contexts;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Contexts;

public class AppSqlServerDbContext
    : SqlServerContext
{
    #region Constructors
    public AppSqlServerDbContext(IConfiguration configuration)
        : base(configuration)
    {
        this._configuration = configuration;
    }
    #endregion Constructors

    #region Fields
    readonly IConfiguration _configuration;
    #endregion Fields

    #region Methods
    public override void ApplyMappings(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AssessmentResultSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new DocumentTemplateSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new EvaluationResultItemSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new EvaluationResultSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new EvaluatorSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new QuestionSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new SortitionParticipantPrintingSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new SortitionParticipantSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new SortitionSqlServerDataModelMap());
        modelBuilder.ApplyConfiguration(new TeamSqlServerDataModelMap());
    }

    public override string ConfigureConnectionString()
    {
        return this._configuration?.GetConnectionString(EFCoreSqlServerConstants.ConnectionStringName) ?? string.Empty;
    }
    #endregion Methods
}
