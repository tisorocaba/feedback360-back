using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class LeadershipQuestionRepository
    : MongoDbRepositoryBase<LeadershipQuestion, LeadershipQuestionMongoDbDataModel, object, Guid>,
    ILeadershipQuestionRepository
{
    #region Constructors
    public LeadershipQuestionRepository(ILeadershipQuestionMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
