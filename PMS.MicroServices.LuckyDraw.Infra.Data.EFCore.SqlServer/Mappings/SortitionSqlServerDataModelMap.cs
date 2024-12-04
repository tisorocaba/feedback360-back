using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class SortitionSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<SortitionDataModel, Guid, SortitionSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<SortitionDataModel> builder)
    {
        builder.Property(p => p.IdTeam)
               .IsRequired();

        builder.Property(p => p.Number)
               .IsRequired();

        builder.Property(p => p.NumberOfParticipants)
               .IsRequired();

        builder.Property(p => p.Content)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.Property(p => p.LastUpdateBy);
        builder.Property(p => p.LastUpdateAt);

        builder.Property(p => p.Active)
               .IsRequired();
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.SortitionTableName;
    #endregion Methods
}
