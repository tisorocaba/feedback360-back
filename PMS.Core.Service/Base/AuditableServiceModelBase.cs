namespace PMS.Core.Service.Base;

public abstract class AuditableServiceModelBase<TKey>
    : ActivableServiceModelBase<TKey>
{
    #region Properties
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
