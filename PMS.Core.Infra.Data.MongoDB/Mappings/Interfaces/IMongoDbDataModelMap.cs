using PMS.Core.Infra.Data.MongoDB.DataModels.Base;

namespace PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;

public interface IMongoDbDataModelMap<TMongoDbDataModel>
    where TMongoDbDataModel : MongoDbDataModelBase
{
    void Map();
}
