using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.ManagementQuestionCollectionName)]
public class ManagementQuestionMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AbbreviationUpperStartingAttributeName)]
    public string? Abbreviation { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QuestionAttributeName)]
    public string? Question { get; set; }
    #endregion Properties
}
