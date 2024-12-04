namespace PMS.Core.Domain.DomainModels.Base;

public abstract class AuditableDomainModelBase<TKey>
    : ActivableDomainModelBase<TKey>
{
    #region Constructors
    public AuditableDomainModelBase()
    {
        this.CreatedAt = DateTime.UtcNow;
    }
    #endregion Constructors

    #region Fields
    DateTime _createdAt;
    #endregion Fields

    #region Properties
    public Guid CreatedBy { get; set; }
    public DateTime CreatedAt
    {
        get { return this._createdAt; }
        set
        {
            if (value != DateTime.MinValue)
                this._createdAt = value;
        }
    }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
