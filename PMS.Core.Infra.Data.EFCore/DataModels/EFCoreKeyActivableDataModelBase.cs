namespace PMS.Core.Infra.Data.EFCore.DataModels;

public abstract class EFCoreKeyActivableDataModelBase<TKey>
    : EFCoreKeyDataModelBase<TKey>
{
    #region Properties
    public bool Active { get; set; }
    #endregion Properties
}
