using MongoDB.Bson.Serialization;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

public class AuthorMongoDbDataModelMap
    : IMongoDbDataModelMap<AuthorMongoDbDataModel>
{
    #region Methods
    public void Map()
    {
        BsonClassMap.RegisterClassMap<AuthorMongoDbDataModel>(classMap =>
        {
            classMap.SetDiscriminator(InfraDataMongoDBConstants.AuthorCollectionName);
            classMap.MapMember(dataModel => dataModel.Id).SetElementName(CoreInfraDataMongoDbConstants.IdAttributeName);
            classMap.MapMember(dataModel => dataModel.Name).SetElementName(InfraDataMongoDBConstants.AuthorsAttributeName);
            classMap.MapMember(dataModel => dataModel.Email).SetElementName(InfraDataMongoDBConstants.EmailAttributeName);
            classMap.MapMember(dataModel => dataModel.HasImmediateSubordinates).SetElementName(InfraDataMongoDBConstants.HasImmediateSubordinatesAttributeName);
            classMap.MapMember(dataModel => dataModel.HasMediateSubordinates).SetElementName(InfraDataMongoDBConstants.HasMediateSubordinatesAttributeName);
            classMap.MapMember(dataModel => dataModel.JobTitle).SetElementName(InfraDataMongoDBConstants.JobTitleAttributeName);
            classMap.MapMember(dataModel => dataModel.BelongsToManagementTeam).SetElementName(InfraDataMongoDBConstants.BelongsToManagementTeamAttributeName);
            classMap.MapMember(dataModel => dataModel.NickName).SetElementName(InfraDataMongoDBConstants.NickNameAttributeName);
            classMap.MapMember(dataModel => dataModel.Placement).SetElementName(InfraDataMongoDBConstants.PlacementAttributeName);
        });
    }
    #endregion Methods
}
