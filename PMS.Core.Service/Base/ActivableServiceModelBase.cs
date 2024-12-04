namespace PMS.Core.Service.Base;

public abstract class ActivableServiceModelBase<TKey>
    : ServiceModelBase<TKey>
{
    #region Properties
    public bool Active { get; set; }
    #endregion Properties
}
