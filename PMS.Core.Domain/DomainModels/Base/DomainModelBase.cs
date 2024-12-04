using PMS.Core.Domain.Attributes;
using PMS.Core.Domain.DomainModels.Interfaces;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Models.Base;
using PMS.Core.Infra.CrossCutting.Utilities;

namespace PMS.Core.Domain.DomainModels.Base;

public abstract class DomainModelBase<TKey>
    : ModelBase<TKey>,
    IDomainModel<TKey>
{
    #region Fields
    TKey _id = default!;
    #endregion Fields

    #region Methods
    public virtual void OnBeforeAdding() { }

    public virtual void OnBeforeUpdating()
    {
        var updatingObject = ((AuditableDomainModelBase<TKey>)this);
        if (updatingObject != null)
        {
            updatingObject.LastUpdateBy = Guid.Empty;
            if (ReflectionUtility.InheritsFrom<AuditableDomainModelBase<TKey>>(this))
                updatingObject.LastUpdateAt = DateTime.UtcNow;
        }
    }

    public virtual bool PrepareForAddingOrUpdate()
    {
        if (this.HasEmptyKey)
        {
            if (typeof(TKey) == typeof(Guid))
            {
                if (ReflectionUtility.HasAttribute<SkipSettingIdOnAddOperationAttribute>(this.GetType()))
                    this.SetId(ReflectionUtility.InstantiateWithParameters<TKey>(Guid.NewGuid().ToString()));
                else
                    this.SetId(TypeUtility.ConvertTo<TKey>(Guid.NewGuid()));
            }
            this.OnBeforeAdding();
        }
        else
            this.OnBeforeUpdating();
        return true;
    }

    public void SetEquivalentBoolean(string propertyName, string equivalentValue)
    {
        if ((!string.IsNullOrWhiteSpace(propertyName)) && (!string.IsNullOrWhiteSpace(equivalentValue)))
        {
            var property = ReflectionUtility.GetProperty(this.GetType(), propertyName);
            if ((property != null) && (property.PropertyType == typeof(bool)))
            {
                var equivalentBoolean = (equivalentValue.ToUpper() == CoreInfraCrossCuttingConstants.UpperPortugueseYes);
                ReflectionUtility.SetPropertyValue(property, this, equivalentBoolean);
            }
        }
    }

    public void SetId(TKey id)
    {
        if (this.HasEmptyKey)
            this._id = id;
    }

    public void SetIdByObjectId(object? objId)
    {
        if (this.HasEmptyKey)
            this.SetId(TypeUtility.ConvertTo<TKey>((objId?.ToString() ?? string.Empty).ToGuid32HexadecimalDigits()));
    }
    #endregion Methods

    #region Properties
    public override TKey Id { get { return this._id; } set { } }
    #endregion Properties
}
