using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.GeneralQuestionCollectionName)]
public class GeneralQuestionMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AbbreviationAttributeName)]
    public string? Abbreviation { get; set; }

    [BsonElement(InfraDataMongoDBConstants.SelfAssessmentQuestionAttributeName)]
    public string? SelfAssessmentQuestion { get; set; }

    [BsonElement(InfraDataMongoDBConstants.CoWorkerQuestionAttributeName)]
    public string? CoWorkerQuestion { get; set; }

    [BsonElement(InfraDataMongoDBConstants.SubordinateQuestionAttributeName)]
    public string? SubordinateQuestion { get; set; }
    #endregion Properties
}
