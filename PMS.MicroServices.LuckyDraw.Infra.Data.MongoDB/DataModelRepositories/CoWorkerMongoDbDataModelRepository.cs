using PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories;

public class CoWorkerMongoDbDataModelRepository
    : MongoDbDataModelRepositoryBase<CoWorkerMongoDbDataModel>,
    ICoWorkerMongoDbDataModelRepository
{
    #region Constructors
    public CoWorkerMongoDbDataModelRepository(IDefaultMongoDbDataContext dataContext)
        : base(dataContext)
    {

    }
    #endregion Constructors
}
