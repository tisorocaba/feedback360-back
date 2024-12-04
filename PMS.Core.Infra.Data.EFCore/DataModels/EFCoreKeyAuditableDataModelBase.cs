namespace PMS.Core.Infra.Data.EFCore.DataModels;

public abstract class EFCoreKeyAuditableDataModelBase<TKey>
    : EFCoreKeyDataModelBase<TKey>
{
    #region Properties
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    #endregion Properties
}
