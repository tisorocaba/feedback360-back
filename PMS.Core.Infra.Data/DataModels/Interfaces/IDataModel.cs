using PMS.Core.Infra.CrossCutting.Models.Interfaces;

namespace PMS.Core.Infra.Data.DataModels.Interfaces;

public interface IDataModel<TKey>
    : IModel<TKey>,
    IDisposable
{

}
