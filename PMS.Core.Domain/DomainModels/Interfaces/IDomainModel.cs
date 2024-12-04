namespace PMS.Core.Domain.DomainModels.Interfaces;

public interface IDomainModel<TKey>
//: IDomainEntity
{
    #region Methods
    bool PrepareForAddingOrUpdate();
    void SetId(TKey id);
    void SetIdByObjectId(object? objId);
    #endregion Methods
}
