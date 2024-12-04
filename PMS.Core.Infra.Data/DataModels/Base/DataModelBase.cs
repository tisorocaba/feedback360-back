using PMS.Core.Infra.CrossCutting.Models.Base;
using PMS.Core.Infra.Data.DataModels.Interfaces;

namespace PMS.Core.Infra.Data.DataModels.Base;

public abstract class DataModelBase<TKey>
    : ModelBase<TKey>,
    IDataModel<TKey>
{
    #region Methods
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    #endregion Methods
}
