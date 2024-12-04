using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.Data.DataModels.Base;
using PMS.Core.Infra.Data.EFCore.Mappings.Base;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;

namespace PMS.Core.Infra.Data.EFCore.SqlServer.Mappings.Base;

public abstract class EFCoreSqlServerDataModelMapBase<TDataModel, TKey, TEFCoreDataModelMap>
    : EFCoreMapBase<TDataModel, TKey, TEFCoreDataModelMap>,
    IEFCoreDataModelMap
    where TDataModel : DataModelBase<TKey>
    where TEFCoreDataModelMap : IEFCoreDataModelMap
{
    #region Methods
    public void Configure(EntityTypeBuilder builder)
    {
        string nameOfId = nameof(DataModelBase<TKey>.Id);
        builder.HasKey(nameOfId);
        if (typeof(TKey).IsAssignableFrom(typeof(int)))
            builder.Property(nameOfId).ValueGeneratedOnAdd().UseIdentityColumn();
        else
            builder.Property(nameOfId).ValueGeneratedNever();
    }
    #endregion Methods
}
