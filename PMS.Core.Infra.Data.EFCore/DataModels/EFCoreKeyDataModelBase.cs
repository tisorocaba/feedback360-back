using PMS.Core.Infra.Data.DataModels.Base;

namespace PMS.Core.Infra.Data.EFCore.DataModels;

public abstract class EFCoreKeyDataModelBase<TKey>
    : DataModelBase<TKey>
{
    #region Properties
    public override TKey Id { get; set; } = default!;
    #endregion Properties
}
