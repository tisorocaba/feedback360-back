using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class GeneralQuestionMongoDbDataModelMap
    : IMongoDbDataModelMap<GeneralQuestionMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<GeneralQuestionMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.GeneralQuestionCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Abbreviation).SetElementName(InfraDataMongoDBConstants.AbbreviationAttributeName);
            classMap.MapMember(dataModel => dataModel.SelfAssessmentQuestion).SetElementName(InfraDataMongoDBConstants.SelfAssessmentQuestionAttributeName);
            classMap.MapMember(dataModel => dataModel.CoWorkerQuestion).SetElementName(InfraDataMongoDBConstants.CoWorkerQuestionAttributeName);
            classMap.MapMember(dataModel => dataModel.SubordinateQuestion).SetElementName(InfraDataMongoDBConstants.SubordinateQuestionAttributeName);
        });
    }
    #endregion Methods
}
