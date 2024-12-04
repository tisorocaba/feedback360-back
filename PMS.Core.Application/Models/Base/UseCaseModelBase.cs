using PMS.Core.Infra.CrossCutting.Models.Base;

namespace PMS.Core.Application.Models.Base;

public abstract class UseCaseModelBase<TKey, TUseCaseModel>
    : ModelBase<TKey>
{
    #region Methods
    public abstract void Bind(TUseCaseModel source);
    #endregion Methods

    #region Properties
    public override TKey Id { get; set; } = default!;
    #endregion Properties
}
