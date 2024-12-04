using MongoDB.Driver;
using PMS.Core.Infra.Data.MongoDB;
using PMS.Core.Infra.Data.MongoDB.DataContexts.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Mappings;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts;

public class DefaultMongoDbDataContext
    : MongoDbDataContextBase,
    IDefaultMongoDbDataContext
{
    #region Constructors
    public DefaultMongoDbDataContext(MongoClient client, MongoDbOptionsLoader loader)
        : base(client, loader)
    {

    }
    #endregion Constructors

    #region Methods
    protected override void InitInternal()
    {
        RegisterMongoCollection(name: InfraDataMongoDBConstants.AuthorCollectionName, mongoDbDataModelMap: new AuthorMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<AuthorMongoDbDataModel>.IndexKeys.Ascending(q => q.Name).Ascending(q => q.NickName);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.CoWorkerCollectionName, mongoDbDataModelMap: new CoWorkerMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<CoWorkerMongoDbDataModel>.IndexKeys.Ascending(q => q.Author).Ascending(q => q.CoWorkerType);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.GeneralQuestionCollectionName, mongoDbDataModelMap: new GeneralQuestionMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<GeneralQuestionMongoDbDataModel>.IndexKeys.Ascending(q => q.Abbreviation);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.ImmediateLeaderCollectionName, mongoDbDataModelMap: new ImmediateLeaderMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<ImmediateLeaderMongoDbDataModel>.IndexKeys.Ascending(q => q.Author).Ascending(q => q.Leader);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.LeadershipQuestionCollectionName, mongoDbDataModelMap: new LeadershipQuestionMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<LeadershipQuestionMongoDbDataModel>.IndexKeys.Ascending(q => q.Abbreviation);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.ManagementQuestionCollectionName, mongoDbDataModelMap: new ManagementQuestionMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<ManagementQuestionMongoDbDataModel>.IndexKeys.Ascending(q => q.Question);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.ManagementTeamCollectionName, mongoDbDataModelMap: new ManagementTeamMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<ManagementTeamMongoDbDataModel>.IndexKeys.Ascending(q => q.Author).Ascending(q => q.MediateLeader).Ascending(q => q.ImmediateLeader);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.MediateLeaderCollectionName, mongoDbDataModelMap: new MediateLeaderMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<MediateLeaderMongoDbDataModel>.IndexKeys.Ascending(q => q.Author).Ascending(q => q.Leader);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.SelfAssessmentCollectionName, mongoDbDataModelMap: new SelfAssessmentMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<SelfAssessmentMongoDbDataModel>.IndexKeys.Ascending(q => q.Author);
            });
        RegisterMongoCollection(name: InfraDataMongoDBConstants.SubordinateCollectionName, mongoDbDataModelMap: new SubordinateMongoDbDataModelMap(),
            indexConfigHandler: () =>
            {
                return Builders<SubordinateMongoDbDataModel>.IndexKeys.Ascending(q => q.LeadershipAuthor)
                                                                      .Ascending(q => q.SubordinateTeam)
                                                                      .Ascending(q => q.SubordinateName);
            });
    }
    #endregion Methods
}
