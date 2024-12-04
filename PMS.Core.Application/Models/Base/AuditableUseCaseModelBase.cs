namespace PMS.Core.Application.Models.Base;

public abstract class AuditableUseCaseModelBase<TKey, TUseCaseModel>
    : ActivableUseCaseModelBase<TKey, TUseCaseModel>
{
    #region Properties
    public DateTime CreatedAt { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
