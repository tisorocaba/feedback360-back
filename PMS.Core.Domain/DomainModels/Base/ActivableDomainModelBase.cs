namespace PMS.Core.Domain.DomainModels.Base;

public abstract class ActivableDomainModelBase<TKey>
    : DomainModelBase<TKey>
{
    #region Constructors
    public ActivableDomainModelBase()
    {
        this.Active = true;
    }
    #endregion Constructors

    #region Methods
    public override void OnBeforeAdding()
    {
        base.OnBeforeAdding();
        this.Active = true;
    }
    #endregion Methods

    #region Properties
    public bool Active { get; set; }
    #endregion Properties
}
