using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class SortitionParticipantSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<SortitionParticipantDataModel, Guid, SortitionParticipantSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<SortitionParticipantDataModel> builder)
    {
        builder.Property(p => p.IdSortition)
               .IsRequired();

        builder.Property(p => p.Number)
               .IsRequired();

        builder.Property(p => p.Code)
               .IsRequired();

        builder.Property(p => p.AccessCounter)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.Property(p => p.LastUpdateBy);
        builder.Property(p => p.LastUpdateAt);

        builder.HasOne(o => o.Sortition)
               .WithMany(m => m.Participants)
               .HasForeignKey(f => f.IdSortition)
               .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.SortitionParticipantTableName;
    #endregion Methods
}
