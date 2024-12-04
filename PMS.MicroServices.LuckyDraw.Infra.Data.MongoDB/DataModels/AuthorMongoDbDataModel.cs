using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.AuthorCollectionName)]
public class AuthorMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AuthorsAttributeName)]
    public string? Name { get; set; }

    [BsonElement(InfraDataMongoDBConstants.EmailAttributeName)]
    public string? Email { get; set; }

    [BsonElement(InfraDataMongoDBConstants.HasImmediateSubordinatesAttributeName)]
    public string HasImmediateSubordinates { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.HasMediateSubordinatesAttributeName)]
    public string HasMediateSubordinates { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.JobTitleAttributeName)]
    public string? JobTitle { get; set; }

    [BsonElement(InfraDataMongoDBConstants.BelongsToManagementTeamAttributeName)]
    public string BelongsToManagementTeam { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.NickNameAttributeName)]
    public string? NickName { get; set; }

    [BsonElement(InfraDataMongoDBConstants.PlacementAttributeName)]
    public string? Placement { get; set; }
    #endregion Properties
}
