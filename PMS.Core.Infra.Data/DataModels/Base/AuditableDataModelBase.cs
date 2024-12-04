namespace PMS.Core.Infra.Data.DataModels.Base;

public abstract class AuditableDataModelBase<TKey>
    : ActivableDataModelBase<TKey>
{
    #region Properties
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
