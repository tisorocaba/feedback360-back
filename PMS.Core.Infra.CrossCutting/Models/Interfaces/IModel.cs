namespace PMS.Core.Infra.CrossCutting.Models.Interfaces;

public interface IModel<TKey>
{
    #region Properties
    bool HasEmptyKey { get; }
    TKey Id { get; set; }
    #endregion Properties
}
