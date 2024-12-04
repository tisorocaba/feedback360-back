namespace PMS.Core.Application.Models.Base;

public abstract class ActivableUseCaseModelBase<TKey, TUseCaseModel>
    : UseCaseModelBase<TKey, TUseCaseModel>
{
    #region Properties
    public bool Active { get; set; }
    #endregion Properties
}
