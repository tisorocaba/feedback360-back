using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class ManagementQuestionMongoDbDataModelMap
    : IMongoDbDataModelMap<ManagementQuestionMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<ManagementQuestionMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.ManagementQuestionCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Abbreviation).SetElementName(InfraDataMongoDBConstants.AbbreviationUpperStartingAttributeName);
            classMap.MapMember(dataModel => dataModel.Question).SetElementName(InfraDataMongoDBConstants.QuestionAttributeName);
        });
    }
    #endregion Methods
}
