using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class AssessmentResultSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<AssessmentResultDataModel, Guid, AssessmentResultSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<AssessmentResultDataModel> builder)
    {
        builder.Property(p => p.IdSortition);

        builder.Property(p => p.Name)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(p => p.NickName)
               .HasMaxLength(256);

        builder.Property(p => p.UserName)
               .HasMaxLength(256);

        builder.Property(p => p.Email)
               .HasMaxLength(256);

        builder.Property(p => p.Code)
               .HasMaxLength(256)
               .IsRequired();

        builder.Property(p => p.BelongsToManagementTeam)
               .IsRequired();

        builder.Property(p => p.HasImmediateSubordinates)
               .IsRequired();

        builder.Property(p => p.HasMediateSubordinates)
               .IsRequired();

        builder.Property(p => p.Active)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.Property(p => p.LastUpdateBy);
        builder.Property(p => p.LastUpdateAt);

        builder.HasOne(o => o.Sortition)
               .WithMany(m => m.AssessmentResults)
               .HasForeignKey(f => f.IdSortition)
               .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.AssessmentResultTableName;
    #endregion Methods
}
