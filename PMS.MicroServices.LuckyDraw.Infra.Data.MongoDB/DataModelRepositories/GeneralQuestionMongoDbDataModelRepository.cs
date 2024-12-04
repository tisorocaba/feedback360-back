using PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories;

public class GeneralQuestionMongoDbDataModelRepository
    : MongoDbDataModelRepositoryBase<GeneralQuestionMongoDbDataModel>,
    IGeneralQuestionMongoDbDataModelRepository
{
    #region Constructors
    public GeneralQuestionMongoDbDataModelRepository(IDefaultMongoDbDataContext dataContext)
        : base(dataContext)
    {

    }
    #endregion Constructors
}
