using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Mappings;

public class EvaluatorSqlServerDataModelMap
    : EFCoreSqlServerDataModelMapBase<EvaluatorDataModel, Guid, EvaluatorSqlServerDataModelMap>,
    IEFCoreDataModelMap
{
    #region Methods
    public override void ConfigureMap(EntityTypeBuilder<EvaluatorDataModel> builder)
    {
        builder.Property(p => p.IdMediateLeader);
        builder.Property(p => p.IdImmediateLeader);

        builder.Property(p => p.Name).HasMaxLength(256);
        builder.Property(p => p.NickName).HasMaxLength(256);
        builder.Property(p => p.Email).HasMaxLength(512);
        builder.Property(p => p.JobTitle).HasMaxLength(256);

        builder.Property(p => p.HasImmediateSubordinates)
               .IsRequired();

        builder.Property(p => p.HasMediateSubordinates)
               .IsRequired();

        builder.Property(p => p.BelongsToManagementTeam)
               .IsRequired();

        builder.Property(p => p.Placement)
               .HasMaxLength(512);

        builder.Property(p => p.Active)
               .IsRequired();

        builder.Property(p => p.CreatedBy)
               .IsRequired();

        builder.Property(p => p.CreatedAt)
               .IsRequired();

        builder.Property(p => p.LastUpdateBy);
        builder.Property(p => p.LastUpdateAt);

        //builder.HasOne(o => o.ImmediateLeader)
        //       .WithMany(m => m.eva)
        //       .HasForeignKey(f => f.IdEvaluator)
        //       .HasPrincipalKey(p => p.Id);
    }

    protected override string GetTableName() => EFCoreSqlServerTableNames.EvaluatorTableName;
    #endregion Methods
}
