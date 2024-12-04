using PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;

public interface IGeneralQuestionMongoDbDataModelRepository
    : IMongoDbDataModelRepository<GeneralQuestionMongoDbDataModel>
{

}
