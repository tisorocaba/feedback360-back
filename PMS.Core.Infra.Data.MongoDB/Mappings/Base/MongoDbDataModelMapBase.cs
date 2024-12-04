using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;

namespace PMS.Core.Infra.Data.MongoDB.Mappings.Base;

public class MongoDbDataModelMapBase
    : IMongoDbDataModelMap<MongoDbDataModelBase>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<MongoDbDataModelBase>(classMap =>
        {
            classMap.MapIdField(dataModel => dataModel.Id).SetSerializer(new GuidSerializer(BsonType.String));

            classMap.MapExtraElementsMember(dataModel => dataModel.ExtraElements);
            classMap.SetDiscriminator(nameof(MongoDbDataModelBase));
        });
    }
    #endregion Methods
}
