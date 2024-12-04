using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class SortitionParticipantPrintingSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<SortitionParticipantPrintingDataModel, Guid, SortitionParticipantPrintingSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<SortitionParticipantPrintingDataModel> builder)
    {
        builder.Property(p => p.IdSortition)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.HasOne(o => o.Sortition)
               .WithMany(m => m.Impressions)
               .HasForeignKey(f => f.IdSortition)
               .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.SortitionParticipantPrintingTableName;
    #endregion Methods
}
