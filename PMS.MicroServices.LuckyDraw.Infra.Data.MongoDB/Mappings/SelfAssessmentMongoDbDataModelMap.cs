using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class SelfAssessmentMongoDbDataModelMap
    : IMongoDbDataModelMap<SelfAssessmentMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<SelfAssessmentMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.SelfAssessmentCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Author).SetElementName(InfraDataMongoDBConstants.AuthorAttributeName);
            classMap.MapMember(dataModel => dataModel.Answer01).SetElementName(InfraDataMongoDBConstants.Q01AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer02).SetElementName(InfraDataMongoDBConstants.Q02AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer03).SetElementName(InfraDataMongoDBConstants.Q03AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer04).SetElementName(InfraDataMongoDBConstants.Q04AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer05).SetElementName(InfraDataMongoDBConstants.Q05AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer06).SetElementName(InfraDataMongoDBConstants.Q06AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer07).SetElementName(InfraDataMongoDBConstants.Q07AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer08).SetElementName(InfraDataMongoDBConstants.Q08AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer09).SetElementName(InfraDataMongoDBConstants.Q09AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer10).SetElementName(InfraDataMongoDBConstants.Q10AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer11).SetElementName(InfraDataMongoDBConstants.Q11AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer12).SetElementName(InfraDataMongoDBConstants.Q12AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer13).SetElementName(InfraDataMongoDBConstants.Q13AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer14).SetElementName(InfraDataMongoDBConstants.Q14AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer15).SetElementName(InfraDataMongoDBConstants.Q15AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer16).SetElementName(InfraDataMongoDBConstants.Q16AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer17).SetElementName(InfraDataMongoDBConstants.Q17AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer18).SetElementName(InfraDataMongoDBConstants.Q18AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer19).SetElementName(InfraDataMongoDBConstants.Q19AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer20).SetElementName(InfraDataMongoDBConstants.Q20AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer21).SetElementName(InfraDataMongoDBConstants.Q21AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer22).SetElementName(InfraDataMongoDBConstants.Q22AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer23).SetElementName(InfraDataMongoDBConstants.Q23AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer24).SetElementName(InfraDataMongoDBConstants.Q24AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer25).SetElementName(InfraDataMongoDBConstants.Q25AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer26).SetElementName(InfraDataMongoDBConstants.Q26AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer27).SetElementName(InfraDataMongoDBConstants.Q27AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer28).SetElementName(InfraDataMongoDBConstants.Q28AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer29).SetElementName(InfraDataMongoDBConstants.Q29AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer30).SetElementName(InfraDataMongoDBConstants.Q30AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer31).SetElementName(InfraDataMongoDBConstants.Q31AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer32).SetElementName(InfraDataMongoDBConstants.Q32AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer33).SetElementName(InfraDataMongoDBConstants.Q33AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer34).SetElementName(InfraDataMongoDBConstants.Q34AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer35).SetElementName(InfraDataMongoDBConstants.Q35AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer36).SetElementName(InfraDataMongoDBConstants.Q36AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer37).SetElementName(InfraDataMongoDBConstants.Q37AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer38).SetElementName(InfraDataMongoDBConstants.Q38AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer39).SetElementName(InfraDataMongoDBConstants.Q39AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer40).SetElementName(InfraDataMongoDBConstants.Q40AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer41).SetElementName(InfraDataMongoDBConstants.Q41AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer42).SetElementName(InfraDataMongoDBConstants.Q42AttributeName);
        });
    }
    #endregion Methods
}
