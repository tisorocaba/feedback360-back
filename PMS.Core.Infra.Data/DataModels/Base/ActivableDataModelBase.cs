namespace PMS.Core.Infra.Data.DataModels.Base;

public abstract class ActivableDataModelBase<TKey>
    : DataModelBase<TKey>
{
    #region Properties
    public bool Active { get; set; }
    #endregion Properties
}
