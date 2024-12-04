using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class ManagementTeamMongoDbDataModelMap
    : IMongoDbDataModelMap<ManagementTeamMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<ManagementTeamMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.ManagementTeamCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Author).SetElementName(InfraDataMongoDBConstants.AuthorAttributeName);
            classMap.MapMember(dataModel => dataModel.ImmediateLeader).SetElementName(InfraDataMongoDBConstants.ImmediateLeaderAttributeName);
            classMap.MapMember(dataModel => dataModel.MediateLeader).SetElementName(InfraDataMongoDBConstants.MediateLeaderAttributeName);
            classMap.MapMember(dataModel => dataModel.Answer01).SetElementName(InfraDataMongoDBConstants.QG01AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer02).SetElementName(InfraDataMongoDBConstants.QG02AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer03).SetElementName(InfraDataMongoDBConstants.QG03AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer04).SetElementName(InfraDataMongoDBConstants.QG04AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer05).SetElementName(InfraDataMongoDBConstants.QG05AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer06).SetElementName(InfraDataMongoDBConstants.QG06AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer07).SetElementName(InfraDataMongoDBConstants.QG07AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer08).SetElementName(InfraDataMongoDBConstants.QG08AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer09).SetElementName(InfraDataMongoDBConstants.QG09AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer10).SetElementName(InfraDataMongoDBConstants.QG10AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer11).SetElementName(InfraDataMongoDBConstants.QG11AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer12).SetElementName(InfraDataMongoDBConstants.QG12AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer13).SetElementName(InfraDataMongoDBConstants.QG13AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer14).SetElementName(InfraDataMongoDBConstants.QG14AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer15).SetElementName(InfraDataMongoDBConstants.QG15AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer16).SetElementName(InfraDataMongoDBConstants.QG16AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer17).SetElementName(InfraDataMongoDBConstants.QG17AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer18).SetElementName(InfraDataMongoDBConstants.QG18AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer19).SetElementName(InfraDataMongoDBConstants.QG19AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer20).SetElementName(InfraDataMongoDBConstants.QG20AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer21).SetElementName(InfraDataMongoDBConstants.QG21AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer22).SetElementName(InfraDataMongoDBConstants.QG22AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer23).SetElementName(InfraDataMongoDBConstants.QG23AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer24).SetElementName(InfraDataMongoDBConstants.QG24AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer25).SetElementName(InfraDataMongoDBConstants.QG25AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer26).SetElementName(InfraDataMongoDBConstants.QG26AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer27).SetElementName(InfraDataMongoDBConstants.QG27AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer28).SetElementName(InfraDataMongoDBConstants.QG28AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer29).SetElementName(InfraDataMongoDBConstants.QG29AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer30).SetElementName(InfraDataMongoDBConstants.QG30AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer31).SetElementName(InfraDataMongoDBConstants.QG31AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer32).SetElementName(InfraDataMongoDBConstants.QG32AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer33).SetElementName(InfraDataMongoDBConstants.QG33AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer34).SetElementName(InfraDataMongoDBConstants.QG34AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer35).SetElementName(InfraDataMongoDBConstants.QG35AttributeName);
        });
    }
    #endregion Methods
}
