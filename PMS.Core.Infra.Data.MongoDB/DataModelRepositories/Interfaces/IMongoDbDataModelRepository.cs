using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using System.Linq.Expressions;

namespace PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Interfaces;

public interface IMongoDbDataModelRepository<TMongoDbDataModel>
    where TMongoDbDataModel : MongoDbDataModelBase
{
    #region Methods
    Task<TMongoDbDataModel> AddAsync(TMongoDbDataModel dataModel, CancellationToken cancellationToken);
    Task<List<TMongoDbDataModel>> FindAsync(Expression<Func<TMongoDbDataModel, bool>> whereExpression, CancellationToken cancellationToken,
                                            params OrderByExpression<TMongoDbDataModel, object?>[] orderByExpressions);
    Task<TMongoDbDataModel?> FindOneAsync(Expression<Func<TMongoDbDataModel, bool>> whereExpression, CancellationToken cancellationToken);
    Task<List<TMongoDbDataModel>> GetAllAsync(params OrderByExpression<TMongoDbDataModel, object?>[] orderByExpressions);
    Task<TMongoDbDataModel?> GetByIdAsync(object? id, CancellationToken cancellationToken);
    Task<TResult> MaxAsync<TResult>(Expression<Func<TMongoDbDataModel, TResult>> expression);
    Task RemoveAsync(object? id, CancellationToken cancellationToken);
    Task RemoveAsync(TMongoDbDataModel? dataModel, CancellationToken cancellationToken);
    Task<TMongoDbDataModel> UpdateAsync(TMongoDbDataModel dataModel, CancellationToken cancellationToken);
    #endregion Methods
}
