using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.MediateLeaderCollectionName)]
public class MediateLeaderMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AuthorAttributeName)]
    public string Author { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.MediateLeaderAttributeName)]
    public string Leader { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.QC01AttributeName)]
    public string? Answer01 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC02AttributeName)]
    public string? Answer02 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC03AttributeName)]
    public string? Answer03 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC04AttributeName)]
    public string? Answer04 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC05AttributeName)]
    public string? Answer05 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC06AttributeName)]
    public string? Answer06 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC07AttributeName)]
    public string? Answer07 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC08AttributeName)]
    public string? Answer08 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC09AttributeName)]
    public string? Answer09 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC10AttributeName)]
    public string? Answer10 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC11AttributeName)]
    public string? Answer11 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC12AttributeName)]
    public string? Answer12 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC13AttributeName)]
    public string? Answer13 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC14AttributeName)]
    public string? Answer14 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC15AttributeName)]
    public string? Answer15 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC16AttributeName)]
    public string? Answer16 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC17AttributeName)]
    public string? Answer17 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC18AttributeName)]
    public string? Answer18 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC19AttributeName)]
    public string? Answer19 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC20AttributeName)]
    public string? Answer20 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC21AttributeName)]
    public string? Answer21 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC22AttributeName)]
    public string? Answer22 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC23AttributeName)]
    public string? Answer23 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC24AttributeName)]
    public string? Answer24 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC25AttributeName)]
    public string? Answer25 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC26AttributeName)]
    public string? Answer26 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC27AttributeName)]
    public string? Answer27 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC28AttributeName)]
    public string? Answer28 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC29AttributeName)]
    public string? Answer29 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC30AttributeName)]
    public string? Answer30 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC31AttributeName)]
    public string? Answer31 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC32AttributeName)]
    public string? Answer32 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC33AttributeName)]
    public string? Answer33 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC34AttributeName)]
    public string? Answer34 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC35AttributeName)]
    public string? Answer35 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC36AttributeName)]
    public string? Answer36 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC37AttributeName)]
    public string? Answer37 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC38AttributeName)]
    public string? Answer38 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC39AttributeName)]
    public string? Answer39 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC40AttributeName)]
    public string? Answer40 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC41AttributeName)]
    public string? Answer41 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC42AttributeName)]
    public string? Answer42 { get; set; }
    #endregion Properties
}
