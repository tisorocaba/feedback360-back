using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class EvaluationResultSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<EvaluationResultDataModel, Guid, EvaluationResultSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<EvaluationResultDataModel> builder)
    {
        builder.Property(p => p.IdSortition);

        builder.Property(p => p.IdEvaluator)
               .IsRequired();

        builder.Property(p => p.IdEvaluatedCoWorker);

        builder.Property(p => p.EvaluatedCoWorkerName)
               .HasMaxLength(256);

        builder.Property(p => p.EvaluatedCoWorkerType)
               .HasMaxLength(1)
               .IsFixedLength(true);

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.HasOne(o => o.Evaluator)
               .WithMany(m => m.EvaluationResults)
               .HasForeignKey(f => f.IdEvaluator)
               .HasPrincipalKey(p => p.Id);

        //builder.HasOne(o => o.EvaluatedCoWorker)
        //       .WithMany(m => m.EvaluationResults)
        //       .HasForeignKey(f => f.IdEvaluatedCoWorker)
        //       .HasPrincipalKey(p => p.Id);

        builder.HasOne(o => o.Sortition)
               .WithMany(m => m.EvaluationResults)
               .HasForeignKey(f => f.IdSortition)
               .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.EvaluationResultTableName;
    #endregion Methods
}
