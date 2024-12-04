using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.LeadershipQuestionCollectionName)]
public class LeadershipQuestionMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AbbreviationAttributeName)]
    public string? Abbreviation { get; set; }

    [BsonElement(InfraDataMongoDBConstants.LeadershipQuestionAttributeName)]
    public string? Question { get; set; }
    #endregion Properties
}
