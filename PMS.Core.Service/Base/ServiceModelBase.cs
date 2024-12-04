using PMS.Core.Infra.CrossCutting.Models.Base;

namespace PMS.Core.Service.Base;

public abstract class ServiceModelBase<TKey>
    : ModelBase<TKey>
{
    #region Properties
    public override TKey Id { get; set; } = default!;
    #endregion Properties
}
