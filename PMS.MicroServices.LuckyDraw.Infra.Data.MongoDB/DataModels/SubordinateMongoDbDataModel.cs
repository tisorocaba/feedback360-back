using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.SubordinateCollectionName)]
public class SubordinateMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.LeadershipAuthorAttributeName)]
    public string LeadershipAuthor { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.HasSubordinatesAttributeName)]
    public string HasSubordinates { get; set; } = default!;

    [BsonElement(InfraDataMongoDBConstants.SubordinateNameAttributeName)]
    public string? SubordinateName { get; set; }

    [BsonElement(InfraDataMongoDBConstants.SubordinateTeamAttributeName)]
    public string? SubordinateTeam { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q01_1AttributeName)]
    public string? Answer01 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q02_1AttributeName)]
    public string? Answer02 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q03_1AttributeName)]
    public string? Answer03 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q04_1AttributeName)]
    public string? Answer04 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q05_1AttributeName)]
    public string? Answer05 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q06_1AttributeName)]
    public string? Answer06 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q07_1AttributeName)]
    public string? Answer07 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q08_1AttributeName)]
    public string? Answer08 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q09_1AttributeName)]
    public string? Answer09 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q10_1AttributeName)]
    public string? Answer10 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q11_1AttributeName)]
    public string? Answer11 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q12_1AttributeName)]
    public string? Answer12 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q13_1AttributeName)]
    public string? Answer13 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q14_1AttributeName)]
    public string? Answer14 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q15_1AttributeName)]
    public string? Answer15 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q16_1AttributeName)]
    public string? Answer16 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q17_1AttributeName)]
    public string? Answer17 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q18_1AttributeName)]
    public string? Answer18 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q19_1AttributeName)]
    public string? Answer19 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q20_1AttributeName)]
    public string? Answer20 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q21_1AttributeName)]
    public string? Answer21 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q22_1AttributeName)]
    public string? Answer22 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q23_1AttributeName)]
    public string? Answer23 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q24_1AttributeName)]
    public string? Answer24 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q25_1AttributeName)]
    public string? Answer25 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q26_1AttributeName)]
    public string? Answer26 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q27_1AttributeName)]
    public string? Answer27 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q28_1AttributeName)]
    public string? Answer28 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q29_1AttributeName)]
    public string? Answer29 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q30_1AttributeName)]
    public string? Answer30 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q31_1AttributeName)]
    public string? Answer31 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q32_1AttributeName)]
    public string? Answer32 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q33_1AttributeName)]
    public string? Answer33 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q34_1AttributeName)]
    public string? Answer34 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q35_1AttributeName)]
    public string? Answer35 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q36_1AttributeName)]
    public string? Answer36 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q37_1AttributeName)]
    public string? Answer37 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q38_1AttributeName)]
    public string? Answer38 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q39_1AttributeName)]
    public string? Answer39 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q40_1AttributeName)]
    public string? Answer40 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q41_1AttributeName)]
    public string? Answer41 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q42_1AttributeName)]
    public string? Answer42 { get; set; }
    #endregion Properties
}
