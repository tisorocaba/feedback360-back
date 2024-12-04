using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class LeadershipQuestionMongoDbDataModelMap
    : IMongoDbDataModelMap<LeadershipQuestionMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<LeadershipQuestionMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.LeadershipQuestionCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Abbreviation).SetElementName(InfraDataMongoDBConstants.AbbreviationAttributeName);
            classMap.MapMember(dataModel => dataModel.Question).SetElementName(InfraDataMongoDBConstants.LeadershipQuestionAttributeName);
        });
    }
    #endregion Methods
}
