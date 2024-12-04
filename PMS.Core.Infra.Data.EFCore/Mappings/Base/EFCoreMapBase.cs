using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.Constants;
using PMS.Core.Infra.Data.DataModels.Base;
using PMS.Core.Infra.Data.DataModels.Interfaces;
using PMS.Core.Infra.Data.EFCore.Mappings.Interfaces;
using System.Dynamic;

namespace PMS.Core.Infra.Data.EFCore.Mappings.Base;

public abstract class EFCoreMapBase<TDataModel, TKey, TEFCoreDataModelMap>
    : IEntityTypeConfiguration<TDataModel>
    where TDataModel : DataModelBase<TKey>
    where TEFCoreDataModelMap : IEFCoreDataModelMap
{
    #region Methods
    public void Configure(EntityTypeBuilder<TDataModel> builder)
    {
        var keyType = typeof(TKey);
        if (keyType == typeof(object) || typeof(IDynamicMetaObjectProvider).IsAssignableFrom(keyType))
            ConfigureCompositePrimaryKey(builder);
        else
            ConfigurePrimaryKey(builder);
        builder.ToTable(GetTableName(), GetSchemaName());
    }

    protected virtual void ConfigureCompositePrimaryKey(EntityTypeBuilder<TDataModel> builder) { }
    public abstract void ConfigureMap(EntityTypeBuilder<TDataModel> builder);

    private void ConfigurePrimaryKey(EntityTypeBuilder<TDataModel> builder)
    {
        if (typeof(IDataModel<TKey>).IsAssignableFrom(typeof(TDataModel)))
            ReflectionUtility.Instantiate<TEFCoreDataModelMap>().Configure(builder);
    }

    protected virtual string GetSchemaName() => RelationalDatabaseConstants.DatabaseOwnerSchema;
    protected abstract string GetTableName();
    #endregion Methods
}
