using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.ManagementTeamCollectionName)]
public class ManagementTeamMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AuthorAttributeName)]
    public string? Author { get; set; }

    [BsonElement(InfraDataMongoDBConstants.ImmediateLeaderAttributeName)]
    public string? ImmediateLeader { get; set; }

    [BsonElement(InfraDataMongoDBConstants.MediateLeaderAttributeName)]
    public string? MediateLeader { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG01AttributeName)]
    public string? Answer01 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG02AttributeName)]
    public string? Answer02 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG03AttributeName)]
    public string? Answer03 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG04AttributeName)]
    public string? Answer04 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG05AttributeName)]
    public string? Answer05 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG06AttributeName)]
    public string? Answer06 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG07AttributeName)]
    public string? Answer07 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG08AttributeName)]
    public string? Answer08 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG09AttributeName)]
    public string? Answer09 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG10AttributeName)]
    public string? Answer10 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG11AttributeName)]
    public string? Answer11 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG12AttributeName)]
    public string? Answer12 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG13AttributeName)]
    public string? Answer13 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG14AttributeName)]
    public string? Answer14 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG15AttributeName)]
    public string? Answer15 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG16AttributeName)]
    public string? Answer16 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG17AttributeName)]
    public string? Answer17 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG18AttributeName)]
    public string? Answer18 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG19AttributeName)]
    public string? Answer19 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG20AttributeName)]
    public string? Answer20 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG21AttributeName)]
    public string? Answer21 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG22AttributeName)]
    public string? Answer22 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG23AttributeName)]
    public string? Answer23 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG24AttributeName)]
    public string? Answer24 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG25AttributeName)]
    public string? Answer25 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG26AttributeName)]
    public string? Answer26 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG27AttributeName)]
    public string? Answer27 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG28AttributeName)]
    public string? Answer28 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG29AttributeName)]
    public string? Answer29 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG30AttributeName)]
    public string? Answer30 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG31AttributeName)]
    public string? Answer31 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG32AttributeName)]
    public string? Answer32 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG33AttributeName)]
    public string? Answer33 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG34AttributeName)]
    public string? Answer34 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QG35AttributeName)]
    public string? Answer35 { get; set; }
    #endregion Properties
}

