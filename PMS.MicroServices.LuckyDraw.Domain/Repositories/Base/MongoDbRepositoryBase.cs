using Mapster;
using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Domain.Repositories.Interfaces;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.Core.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.AdapterConfigurations;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;

public abstract class MongoDbRepositoryBase<TDomainModel, TDataModel, TOrderBy, TKey>
    : IRepository<TDomainModel, TKey>
    where TDomainModel : DomainModelBase<TKey>
    where TDataModel : MongoDbDataModelBase
{
    #region Constructors
    public MongoDbRepositoryBase(IMongoDbDataModelRepository<TDataModel> mongoDbDataModelRepository)
    {
        this._mongoDbDataModelRepository = mongoDbDataModelRepository;
        this._typeAdapterConfig = DomainModelAdapterConfiguration.GetAdapterConfig();
    }
    #endregion Constructors

    #region Fields
    readonly IMongoDbDataModelRepository<TDataModel> _mongoDbDataModelRepository;
    readonly TypeAdapterConfig _typeAdapterConfig;
    #endregion Fields

    #region Methods
    public async Task<TDomainModel> AddAsync(TDomainModel model)
    {
        var dataModel = model.Adapt<TDataModel>(this._typeAdapterConfig);
        await this._mongoDbDataModelRepository.AddAsync(dataModel, new CancellationToken());
        return dataModel.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    protected OrderByExpression<TDataModel, object?>[] ConvertOrderByExpressions(OrderByExpression<TDomainModel, object?>[] expressions)
    {
        var orderByExpressions = (OrderByExpression<TDataModel, object?>[])Array.CreateInstance(typeof(OrderByExpression<TDataModel, object?>), expressions.Length);
        for (int currentIndex = 0; currentIndex < expressions.Length; currentIndex++)
            orderByExpressions[currentIndex] = expressions[currentIndex].ConvertTo<TDomainModel, TDataModel, object?>();
        return orderByExpressions;
    }

    public virtual async Task<List<TDomainModel>> FindAsync(Expression<Func<TDomainModel, bool>> expression, params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        var dataModels = await this._mongoDbDataModelRepository.FindAsync(expression.ConvertTo<TDomainModel, TDataModel, bool>(), new CancellationToken());
        var domainModels = new List<TDomainModel>(dataModels.Count());
        dataModels.ToList().ForEach(e => domainModels.Add(e.Adapt<TDomainModel>(this._typeAdapterConfig)));
        return domainModels;
    }

    public virtual async Task<TDomainModel?> FindOneAsync(Expression<Func<TDomainModel, bool>> expression)
    {
        var dataModel = await this._mongoDbDataModelRepository.FindOneAsync(expression.ConvertTo<TDomainModel, TDataModel, bool>(), new CancellationToken());
        return dataModel?.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    public virtual async Task<List<TDomainModel>> GetAllAsync(params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        var dataModels = await this._mongoDbDataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<TDomainModel>(dataModels.Count());
        dataModels.ToList().ForEach(e => domainModels.Add(e.Adapt<TDomainModel>(this._typeAdapterConfig)));
        return domainModels;
    }

    public virtual async Task<TDomainModel?> GetByIdAsync(TKey id)
    {
        var dataModel = await this._mongoDbDataModelRepository.GetByIdAsync(id, new CancellationToken());
        return dataModel?.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    public async Task<TResult> MaxAsync<TResult>(Expression<Func<TDomainModel, TResult>> expression)
    {
        return await this._mongoDbDataModelRepository.MaxAsync(expression.ConvertTo<TDomainModel, TDataModel, TResult>());
    }

    public async Task RemoveAsync(TKey id)
    {
        await this._mongoDbDataModelRepository.RemoveAsync(id, new CancellationToken());
    }

    public async Task RemoveAsync(TDomainModel model)
    {
        await this._mongoDbDataModelRepository.RemoveAsync(model.Id, new CancellationToken());
    }

    public async Task<TDomainModel> SaveAsync(TDomainModel model)
    {
        return await this.UpdateAsync(model);
    }

    public async Task<TDomainModel> UpdateAsync(TDomainModel model)
    {
        var dataModel = model.Adapt<TDataModel>(this._typeAdapterConfig);
        var result = await this._mongoDbDataModelRepository.UpdateAsync(dataModel, new CancellationToken());
        return result.Adapt<TDomainModel>(this._typeAdapterConfig);
    }
    #endregion Methods

    #region Properties
    public TypeAdapterConfig AdapterConfig { get { return this._typeAdapterConfig; } }
    public IMongoDbDataModelRepository<TDataModel> DataModelRepository { get { return this._mongoDbDataModelRepository; } }
    #endregion Properties
}
