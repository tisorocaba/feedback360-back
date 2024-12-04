using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class AuthorRepository
    : MongoDbRepositoryBase<Author, AuthorMongoDbDataModel, object, Guid>,
    IAuthorRepository
{
    #region Constructors
    public AuthorRepository(IAuthorMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
