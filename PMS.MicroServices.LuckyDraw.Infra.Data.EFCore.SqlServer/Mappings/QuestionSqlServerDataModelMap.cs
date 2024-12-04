using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class QuestionSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<QuestionDataModel, Guid, QuestionSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<QuestionDataModel> builder)
    {
        builder.Property(p => p.Abbreviation)
               .HasMaxLength(50);

        builder.Property(p => p.Content);
        builder.Property(p => p.SelfAssessmentContent);
        builder.Property(p => p.CoWorkerContent);
        builder.Property(p => p.SubordinateContent);

        builder.Property(p => p.QuestionType)
               .IsRequired();

        builder.Property(p => p.PurposeType)
               .IsRequired();

        builder.Property(p => p.Active)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.Property(p => p.LastUpdateBy);
        builder.Property(p => p.LastUpdateAt);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.QuestionTableName;
    #endregion Methods
}
