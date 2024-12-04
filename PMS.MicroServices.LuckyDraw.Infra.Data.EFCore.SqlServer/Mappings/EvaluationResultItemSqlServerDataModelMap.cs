using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class EvaluationResultItemSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<EvaluationResultItemDataModel, Guid, EvaluationResultItemSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<EvaluationResultItemDataModel> builder)
    {
        builder.Property(p => p.IdEvaluationResult)
               .IsRequired();

        builder.Property(p => p.IdQuestion);

        builder.Property(p => p.ResultValue);
        builder.Property(p => p.ResultText);

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.HasOne(o => o.EvaluationResult)
               .WithMany(m => m.EvaluationResultItems)
               .HasForeignKey(f => f.IdEvaluationResult)
               .HasPrincipalKey(p => p.Id);

        builder.HasOne(o => o.Question)
               .WithMany(m => m.EvaluationResultItems)
               .HasForeignKey(f => f.IdQuestion)
               .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.EvaluationResultItemTableName;
    #endregion Methods
}
