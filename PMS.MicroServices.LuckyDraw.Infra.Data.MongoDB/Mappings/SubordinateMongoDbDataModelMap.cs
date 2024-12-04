using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class SubordinateMongoDbDataModelMap
    : IMongoDbDataModelMap<SubordinateMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<SubordinateMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.SubordinateCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.LeadershipAuthor).SetElementName(InfraDataMongoDBConstants.LeadershipAuthorAttributeName);
            classMap.MapMember(dataModel => dataModel.HasSubordinates).SetElementName(InfraDataMongoDBConstants.HasSubordinatesAttributeName);
            classMap.MapMember(dataModel => dataModel.SubordinateName).SetElementName(InfraDataMongoDBConstants.SubordinateNameAttributeName);
            classMap.MapMember(dataModel => dataModel.SubordinateTeam).SetElementName(InfraDataMongoDBConstants.SubordinateTeamAttributeName);
            classMap.MapMember(dataModel => dataModel.Answer01).SetElementName(InfraDataMongoDBConstants.Q01_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer02).SetElementName(InfraDataMongoDBConstants.Q02_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer03).SetElementName(InfraDataMongoDBConstants.Q03_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer04).SetElementName(InfraDataMongoDBConstants.Q04_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer05).SetElementName(InfraDataMongoDBConstants.Q05_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer06).SetElementName(InfraDataMongoDBConstants.Q06_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer07).SetElementName(InfraDataMongoDBConstants.Q07_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer08).SetElementName(InfraDataMongoDBConstants.Q08_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer09).SetElementName(InfraDataMongoDBConstants.Q09_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer10).SetElementName(InfraDataMongoDBConstants.Q10_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer11).SetElementName(InfraDataMongoDBConstants.Q11_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer12).SetElementName(InfraDataMongoDBConstants.Q12_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer13).SetElementName(InfraDataMongoDBConstants.Q13_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer14).SetElementName(InfraDataMongoDBConstants.Q14_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer15).SetElementName(InfraDataMongoDBConstants.Q15_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer16).SetElementName(InfraDataMongoDBConstants.Q16_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer17).SetElementName(InfraDataMongoDBConstants.Q17_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer18).SetElementName(InfraDataMongoDBConstants.Q18_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer19).SetElementName(InfraDataMongoDBConstants.Q19_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer20).SetElementName(InfraDataMongoDBConstants.Q20_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer21).SetElementName(InfraDataMongoDBConstants.Q21_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer22).SetElementName(InfraDataMongoDBConstants.Q22_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer23).SetElementName(InfraDataMongoDBConstants.Q23_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer24).SetElementName(InfraDataMongoDBConstants.Q24_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer25).SetElementName(InfraDataMongoDBConstants.Q25_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer26).SetElementName(InfraDataMongoDBConstants.Q26_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer27).SetElementName(InfraDataMongoDBConstants.Q27_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer28).SetElementName(InfraDataMongoDBConstants.Q28_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer29).SetElementName(InfraDataMongoDBConstants.Q29_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer30).SetElementName(InfraDataMongoDBConstants.Q30_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer31).SetElementName(InfraDataMongoDBConstants.Q31_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer32).SetElementName(InfraDataMongoDBConstants.Q32_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer33).SetElementName(InfraDataMongoDBConstants.Q33_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer34).SetElementName(InfraDataMongoDBConstants.Q34_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer35).SetElementName(InfraDataMongoDBConstants.Q35_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer36).SetElementName(InfraDataMongoDBConstants.Q36_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer37).SetElementName(InfraDataMongoDBConstants.Q37_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer38).SetElementName(InfraDataMongoDBConstants.Q38_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer39).SetElementName(InfraDataMongoDBConstants.Q39_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer40).SetElementName(InfraDataMongoDBConstants.Q40_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer41).SetElementName(InfraDataMongoDBConstants.Q41_1AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer42).SetElementName(InfraDataMongoDBConstants.Q42_1AttributeName);
        });
    }
    #endregion Methods
}
