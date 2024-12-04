using MongoDB.Driver;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using System.Linq.Expressions;

namespace PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Base;

public abstract class MongoDbDataModelRepositoryBase<TMongoDbDataModel>
    : IMongoDbDataModelRepository<TMongoDbDataModel>
    where TMongoDbDataModel : MongoDbDataModelBase
{
    #region Constructors
    public MongoDbDataModelRepositoryBase(IMongoDbDataContext dataContext)
    {
        this.DataContext = dataContext;
        this.Collection = DataContext.GetCollection<TMongoDbDataModel>();
    }
    #endregion Constructors

    #region Methods
    public async Task<TMongoDbDataModel> AddAsync(TMongoDbDataModel dataModel, CancellationToken cancellationToken)
    {
        if (DataContext.ClientSessionHandle is null)
            await Collection.InsertOneAsync(dataModel, options: null, cancellationToken: cancellationToken);
        else
            await Collection.InsertOneAsync(DataContext.ClientSessionHandle, dataModel, options: null, cancellationToken: cancellationToken);
        return dataModel;
    }

    private IFindFluent<TMongoDbDataModel, TMongoDbDataModel> ApplyOrderBy(IFindFluent<TMongoDbDataModel, TMongoDbDataModel> findable, 
                                                                           OrderByExpression<TMongoDbDataModel, object?>? orderByExpression = null)
    {
        if ((orderByExpression != null) && (orderByExpression.OrderBy != null))
        {
            if (orderByExpression.Descending)
                return findable.SortByDescending(orderByExpression.OrderBy);
            else
                return findable.SortBy(orderByExpression.OrderBy);
        }
        return findable;
    }

    private IFindFluent<TMongoDbDataModel, TMongoDbDataModel> ApplyOrderByArray(IFindFluent<TMongoDbDataModel, TMongoDbDataModel> findable,
                                                                                OrderByExpression<TMongoDbDataModel, object?>[] orderByExpressions)
    {
        if (orderByExpressions?.Any() ?? false)
        {
            if (orderByExpressions.Length == 1)
                findable = ApplyOrderBy(findable, orderByExpressions[0]);
            else
            {
                IOrderedFindFluent<TMongoDbDataModel, TMongoDbDataModel>? orderedFindable = null;
                for (int currentIndex = 0; currentIndex < orderByExpressions.Length; currentIndex++)
                {
                    var currentOrderByExpression = orderByExpressions[currentIndex];
                    if (currentOrderByExpression?.OrderBy != null)
                    {
                        if (currentIndex == 0)
                        {
                            if (currentOrderByExpression.Descending)
                                orderedFindable = findable.SortByDescending(currentOrderByExpression.OrderBy);
                            else
                                orderedFindable = findable.SortBy(currentOrderByExpression.OrderBy);
                        }
                        else
                        {
                            if (currentOrderByExpression.Descending)
                                orderedFindable = orderedFindable?.ThenByDescending(currentOrderByExpression.OrderBy);
                            else
                                orderedFindable = orderedFindable?.ThenBy(currentOrderByExpression.OrderBy);
                        }
                    }
                }
                findable = orderedFindable ?? findable;
            }
        }
        return findable;
    }

    public async Task<List<TMongoDbDataModel>> FindAsync(Expression<Func<TMongoDbDataModel, bool>> whereExpression, CancellationToken cancellationToken,
                                                         params OrderByExpression<TMongoDbDataModel, object?>[] orderByExpressions)
    {
        var findable = Collection.Find(filter: whereExpression, options: null);
        findable = this.ApplyOrderByArray(findable, orderByExpressions);
        return await findable.ToListAsync(cancellationToken);
    }

    public async Task<TMongoDbDataModel?> FindOneAsync(Expression<Func<TMongoDbDataModel, bool>> whereExpression, CancellationToken cancellationToken)
    {
        return await Collection.Find(filter: whereExpression, options: null).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<TMongoDbDataModel>> GetAllAsync(params OrderByExpression<TMongoDbDataModel, object?>[] orderByExpressions)
    {
        var findable = Collection.Find(Builders<TMongoDbDataModel>.Filter.Empty);
        findable = this.ApplyOrderByArray(findable, orderByExpressions);
        return await findable.ToListAsync();
    }

    public async Task<TMongoDbDataModel?> GetByIdAsync(object? id, CancellationToken cancellationToken)
    {
        if (TypeUtility.IsSetByDefault(id))
            return null;
        return await Collection.Find(filter: x => (x != null) && Equals(x.Id, id), options: null).FirstOrDefaultAsync(cancellationToken);
    }

    public Task<TResult> MaxAsync<TResult>(Expression<Func<TMongoDbDataModel, TResult>> expression)
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(object? id, CancellationToken cancellationToken)
    {
        if ((id != null) && (!TypeUtility.IsSetByDefault(id)))
            await this.Collection.DeleteOneAsync(x => Equals(x.Id, id));
    }

    public async Task RemoveAsync(TMongoDbDataModel? dataModel, CancellationToken cancellationToken)
    {
        if (dataModel != null)
            await this.RemoveAsync(dataModel.Id, cancellationToken);
    }

    public async Task RemoveRangeAsync(CancellationToken cancellationToken, params TMongoDbDataModel[] range)
    {
        await Task.CompletedTask;
    }

    public async Task<TMongoDbDataModel> UpdateAsync(TMongoDbDataModel dataModel, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        throw new NotImplementedException();
    }
    #endregion Methods

    #region Properties
    protected IMongoCollection<TMongoDbDataModel> Collection { get; private set; }
    protected IMongoDbDataContext DataContext { get; private set; }
    #endregion Properties
}
