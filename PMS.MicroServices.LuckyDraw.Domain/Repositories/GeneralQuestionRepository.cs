using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class GeneralQuestionRepository
    : MongoDbRepositoryBase<GeneralQuestion, GeneralQuestionMongoDbDataModel, object, Guid>,
    IGeneralQuestionRepository
{
    #region Constructors
    public GeneralQuestionRepository(IGeneralQuestionMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
