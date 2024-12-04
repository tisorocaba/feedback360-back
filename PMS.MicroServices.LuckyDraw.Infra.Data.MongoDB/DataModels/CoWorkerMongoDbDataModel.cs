using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

[BsonDiscriminator(InfraDataMongoDBConstants.CoWorkerCollectionName)]
public class CoWorkerMongoDbDataModel
    : MongoDbDataModelBase
{
    #region Properties
    [BsonElement(InfraDataMongoDBConstants.AuthorAttributeName)]
    public string? Author { get; set; }

    [BsonElement(InfraDataMongoDBConstants.EvaluatedCoWorkerAttributeName)]
    public string? EvaluatedCoWorker { get; set; }

    [BsonElement(InfraDataMongoDBConstants.CoWorkerTypeAttributeName)]
    public string? CoWorkerType { get; set; }

    [BsonElement(InfraDataMongoDBConstants.CoWorkerTeamAttributeName)]
    public string? CoWorkerTeam { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q01AttributeName)]
    public string? Answer01 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q02AttributeName)]
    public string? Answer02 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q03AttributeName)]
    public string? Answer03 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q04AttributeName)]
    public string? Answer04 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q05AttributeName)]
    public string? Answer05 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q06AttributeName)]
    public string? Answer06 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q07AttributeName)]
    public string? Answer07 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q08AttributeName)]
    public string? Answer08 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q09AttributeName)]
    public string? Answer09 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q10AttributeName)]
    public string? Answer10 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q11AttributeName)]
    public string? Answer11 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q12AttributeName)]
    public string? Answer12 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q13AttributeName)]
    public string? Answer13 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q14AttributeName)]
    public string? Answer14 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q15AttributeName)]
    public string? Answer15 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q16AttributeName)]
    public string? Answer16 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q17AttributeName)]
    public string? Answer17 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q18AttributeName)]
    public string? Answer18 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q19AttributeName)]
    public string? Answer19 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q20AttributeName)]
    public string? Answer20 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q21AttributeName)]
    public string? Answer21 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q22AttributeName)]
    public string? Answer22 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q23AttributeName)]
    public string? Answer23 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q24AttributeName)]
    public string? Answer24 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q25AttributeName)]
    public string? Answer25 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q26AttributeName)]
    public string? Answer26 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q27AttributeName)]
    public string? Answer27 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q28AttributeName)]
    public string? Answer28 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q29AttributeName)]
    public string? Answer29 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q30AttributeName)]
    public string? Answer30 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q31AttributeName)]
    public string? Answer31 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q32AttributeName)]
    public string? Answer32 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q33AttributeName)]
    public string? Answer33 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q34AttributeName)]
    public string? Answer34 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q35AttributeName)]
    public string? Answer35 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q36AttributeName)]
    public string? Answer36 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q37AttributeName)]
    public string? Answer37 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q38AttributeName)]
    public string? Answer38 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q39AttributeName)]
    public string? Answer39 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q40AttributeName)]
    public string? Answer40 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q41AttributeName)]
    public string? Answer41 { get; set; }

    [BsonElement(InfraDataMongoDBConstants.Q42AttributeName)]
    public string? Answer42 { get; set; }
    #endregion Properties
}
