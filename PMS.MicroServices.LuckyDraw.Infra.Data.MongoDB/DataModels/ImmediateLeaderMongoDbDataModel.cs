using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.ImmediateLeaderCollectionName)]
public class ImmediateLeaderMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AuthorAttributeName)]
    public string Author { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.ImmediateLeaderAttributeName)]
    public string Leader { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.QC43AttributeName)]
    public string? Answer01 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC44AttributeName)]
    public string? Answer02 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC45AttributeName)]
    public string? Answer03 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC46AttributeName)]
    public string? Answer04 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC47AttributeName)]
    public string? Answer05 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC48AttributeName)]
    public string? Answer06 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC49AttributeName)]
    public string? Answer07 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC50AttributeName)]
    public string? Answer08 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC51AttributeName)]
    public string? Answer09 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC52AttributeName)]
    public string? Answer10 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC53AttributeName)]
    public string? Answer11 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC54AttributeName)]
    public string? Answer12 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC55AttributeName)]
    public string? Answer13 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC56AttributeName)]
    public string? Answer14 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC57AttributeName)]
    public string? Answer15 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC58AttributeName)]
    public string? Answer16 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC59AttributeName)]
    public string? Answer17 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC60AttributeName)]
    public string? Answer18 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC61AttributeName)]
    public string? Answer19 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC62AttributeName)]
    public string? Answer20 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC63AttributeName)]
    public string? Answer21 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC64AttributeName)]
    public string? Answer22 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC65AttributeName)]
    public string? Answer23 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC66AttributeName)]
    public string? Answer24 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC67AttributeName)]
    public string? Answer25 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC68AttributeName)]
    public string? Answer26 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC69AttributeName)]
    public string? Answer27 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC70AttributeName)]
    public string? Answer28 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC71AttributeName)]
    public string? Answer29 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC72AttributeName)]
    public string? Answer30 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC73AttributeName)]
    public string? Answer31 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC74AttributeName)]
    public string? Answer32 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC75AttributeName)]
    public string? Answer33 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC76AttributeName)]
    public string? Answer34 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC77AttributeName)]
    public string? Answer35 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC78AttributeName)]
    public string? Answer36 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC79AttributeName)]
    public string? Answer37 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC80AttributeName)]
    public string? Answer38 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC81AttributeName)]
    public string? Answer39 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC82AttributeName)]
    public string? Answer40 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC83AttributeName)]
    public string? Answer41 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.QC84AttributeName)]
    public string? Answer42 { get; set; }
    #endregion Properties
}
