using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class MediateLeaderMongoDbDataModelMap
    : IMongoDbDataModelMap<MediateLeaderMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<MediateLeaderMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.MediateLeaderCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Author).SetElementName(InfraDataMongoDBConstants.AuthorAttributeName);
            classMap.MapMember(dataModel => dataModel.Leader).SetElementName(InfraDataMongoDBConstants.MediateLeaderAttributeName);
            classMap.MapMember(dataModel => dataModel.Answer01).SetElementName(InfraDataMongoDBConstants.QC01AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer02).SetElementName(InfraDataMongoDBConstants.QC02AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer03).SetElementName(InfraDataMongoDBConstants.QC03AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer04).SetElementName(InfraDataMongoDBConstants.QC04AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer05).SetElementName(InfraDataMongoDBConstants.QC05AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer06).SetElementName(InfraDataMongoDBConstants.QC06AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer07).SetElementName(InfraDataMongoDBConstants.QC07AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer08).SetElementName(InfraDataMongoDBConstants.QC08AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer09).SetElementName(InfraDataMongoDBConstants.QC09AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer10).SetElementName(InfraDataMongoDBConstants.QC10AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer11).SetElementName(InfraDataMongoDBConstants.QC11AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer12).SetElementName(InfraDataMongoDBConstants.QC12AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer13).SetElementName(InfraDataMongoDBConstants.QC13AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer14).SetElementName(InfraDataMongoDBConstants.QC14AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer15).SetElementName(InfraDataMongoDBConstants.QC15AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer16).SetElementName(InfraDataMongoDBConstants.QC16AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer17).SetElementName(InfraDataMongoDBConstants.QC17AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer18).SetElementName(InfraDataMongoDBConstants.QC18AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer19).SetElementName(InfraDataMongoDBConstants.QC19AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer20).SetElementName(InfraDataMongoDBConstants.QC20AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer21).SetElementName(InfraDataMongoDBConstants.QC21AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer22).SetElementName(InfraDataMongoDBConstants.QC22AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer23).SetElementName(InfraDataMongoDBConstants.QC23AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer24).SetElementName(InfraDataMongoDBConstants.QC24AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer25).SetElementName(InfraDataMongoDBConstants.QC25AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer26).SetElementName(InfraDataMongoDBConstants.QC26AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer27).SetElementName(InfraDataMongoDBConstants.QC27AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer28).SetElementName(InfraDataMongoDBConstants.QC28AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer29).SetElementName(InfraDataMongoDBConstants.QC29AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer30).SetElementName(InfraDataMongoDBConstants.QC30AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer31).SetElementName(InfraDataMongoDBConstants.QC31AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer32).SetElementName(InfraDataMongoDBConstants.QC32AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer33).SetElementName(InfraDataMongoDBConstants.QC33AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer34).SetElementName(InfraDataMongoDBConstants.QC34AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer35).SetElementName(InfraDataMongoDBConstants.QC35AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer36).SetElementName(InfraDataMongoDBConstants.QC36AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer37).SetElementName(InfraDataMongoDBConstants.QC37AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer38).SetElementName(InfraDataMongoDBConstants.QC38AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer39).SetElementName(InfraDataMongoDBConstants.QC39AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer40).SetElementName(InfraDataMongoDBConstants.QC40AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer41).SetElementName(InfraDataMongoDBConstants.QC41AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer42).SetElementName(InfraDataMongoDBConstants.QC42AttributeName);
        });
    }
    #endregion Methods
}
