using MongoDB.Driver;

namespace PMS.Core.Infra.Data.MongoDB.DataContexts.Interfaces;

public interface IMongoDbDataContext
    : IDataContext
{
    #region Methods
    IMongoCollection<TMongoDbDataModel> GetCollection<TMongoDbDataModel>();
    #endregion Methods

    #region Properties
    IClientSessionHandle? ClientSessionHandle { get; set; }
    #endregion Properties
}
