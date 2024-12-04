using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class ImmediateLeaderMongoDbDataModelMap
    : IMongoDbDataModelMap<ImmediateLeaderMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<ImmediateLeaderMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.ImmediateLeaderCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Author).SetElementName(InfraDataMongoDBConstants.AuthorAttributeName);
            classMap.MapMember(dataModel => dataModel.Leader).SetElementName(InfraDataMongoDBConstants.ImmediateLeaderAttributeName);
            classMap.MapMember(dataModel => dataModel.Answer01).SetElementName(InfraDataMongoDBConstants.QC43AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer02).SetElementName(InfraDataMongoDBConstants.QC44AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer03).SetElementName(InfraDataMongoDBConstants.QC45AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer04).SetElementName(InfraDataMongoDBConstants.QC46AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer05).SetElementName(InfraDataMongoDBConstants.QC47AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer06).SetElementName(InfraDataMongoDBConstants.QC48AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer07).SetElementName(InfraDataMongoDBConstants.QC49AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer08).SetElementName(InfraDataMongoDBConstants.QC50AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer09).SetElementName(InfraDataMongoDBConstants.QC51AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer10).SetElementName(InfraDataMongoDBConstants.QC52AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer11).SetElementName(InfraDataMongoDBConstants.QC53AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer12).SetElementName(InfraDataMongoDBConstants.QC54AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer13).SetElementName(InfraDataMongoDBConstants.QC55AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer14).SetElementName(InfraDataMongoDBConstants.QC56AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer15).SetElementName(InfraDataMongoDBConstants.QC57AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer16).SetElementName(InfraDataMongoDBConstants.QC58AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer17).SetElementName(InfraDataMongoDBConstants.QC59AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer18).SetElementName(InfraDataMongoDBConstants.QC60AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer19).SetElementName(InfraDataMongoDBConstants.QC61AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer20).SetElementName(InfraDataMongoDBConstants.QC62AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer21).SetElementName(InfraDataMongoDBConstants.QC63AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer22).SetElementName(InfraDataMongoDBConstants.QC64AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer23).SetElementName(InfraDataMongoDBConstants.QC65AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer24).SetElementName(InfraDataMongoDBConstants.QC66AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer25).SetElementName(InfraDataMongoDBConstants.QC67AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer26).SetElementName(InfraDataMongoDBConstants.QC68AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer27).SetElementName(InfraDataMongoDBConstants.QC69AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer28).SetElementName(InfraDataMongoDBConstants.QC70AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer29).SetElementName(InfraDataMongoDBConstants.QC71AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer30).SetElementName(InfraDataMongoDBConstants.QC72AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer31).SetElementName(InfraDataMongoDBConstants.QC73AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer32).SetElementName(InfraDataMongoDBConstants.QC74AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer33).SetElementName(InfraDataMongoDBConstants.QC75AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer34).SetElementName(InfraDataMongoDBConstants.QC76AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer35).SetElementName(InfraDataMongoDBConstants.QC77AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer36).SetElementName(InfraDataMongoDBConstants.QC78AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer37).SetElementName(InfraDataMongoDBConstants.QC79AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer38).SetElementName(InfraDataMongoDBConstants.QC80AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer39).SetElementName(InfraDataMongoDBConstants.QC81AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer40).SetElementName(InfraDataMongoDBConstants.QC82AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer41).SetElementName(InfraDataMongoDBConstants.QC83AttributeName);
            classMap.MapMember(dataModel => dataModel.Answer42).SetElementName(InfraDataMongoDBConstants.QC84AttributeName);
        });
    }
    #endregion Methods
}
