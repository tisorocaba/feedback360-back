using PMS.Core.Infra.CrossCutting.Models.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;

namespace PMS.Core.Infra.CrossCutting.Models.Base;

public abstract class ModelBase<TKey>
    : IModel<TKey>
{
    #region Properties
    public bool HasEmptyKey { get { return TypeUtility.IsSetByDefault(this.Id); } }
    public abstract TKey Id { get; set; }
    #endregion Properties
}
