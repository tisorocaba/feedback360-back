using Mapster;
using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Domain.Repositories.Interfaces;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.Core.Infra.Data.DataModels.Base;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.AdapterConfigurations;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;

public abstract class RepositoryBase<TDomainModel, TDataModel, TOrderBy, TKey>
    : IRepository<TDomainModel, TKey>
    where TDomainModel : DomainModelBase<TKey>
    where TDataModel : DataModelBase<TKey>
{
    #region Constructors
    public RepositoryBase(IEFCoreDataModelRepository<TDataModel, TKey> dataModelRepository)
    {
        this._dataModelRepository = dataModelRepository;
        this._typeAdapterConfig = DomainModelAdapterConfiguration.GetAdapterConfig();
    }
    #endregion Constructors

    #region Fields
    readonly IEFCoreDataModelRepository<TDataModel, TKey> _dataModelRepository;
    readonly TypeAdapterConfig _typeAdapterConfig;
    #endregion Fields

    #region Methods
    public async Task<TDomainModel> AddAsync(TDomainModel model)
    {
        var dataModel = model.Adapt<TDataModel>(this._typeAdapterConfig);
        var result = await this._dataModelRepository.AddAsync(dataModel);
        return result.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    OrderByExpression<TDataModel, object?>[] ConvertOrderByExpressions(OrderByExpression<TDomainModel, object?>[] expressions)
    {
        var orderByExpressions = (OrderByExpression<TDataModel, object?>[])Array.CreateInstance(typeof(OrderByExpression<TDataModel, object?>), expressions.Length);
        for (int currentIndex = 0; currentIndex < expressions.Length; currentIndex++)
            orderByExpressions[currentIndex] = expressions[currentIndex].ConvertTo<TDomainModel, TDataModel, object?>();
        return orderByExpressions;
    }

    public async Task<List<TDomainModel>> FindAsync(Expression<Func<TDomainModel, bool>> expression, params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        var dataModels = await this._dataModelRepository.FindAsync(expression.ConvertTo<TDomainModel, TDataModel, bool>(), ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<TDomainModel>(dataModels.Count());
        dataModels.ToList().ForEach(e => domainModels.Add(e.Adapt<TDomainModel>(this._typeAdapterConfig)));
        return domainModels;
    }

    public async Task<TDomainModel?> FindOneAsync(Expression<Func<TDomainModel, bool>> expression)
    {
        var dataModel = await this._dataModelRepository.FindOneAsync(expression.ConvertTo<TDomainModel, TDataModel, bool>());
        return dataModel?.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    public async Task<List<TDomainModel>> GetAllAsync(params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        var dataModels = await this._dataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<TDomainModel>(dataModels.Count());
        dataModels.ToList().ForEach(e => domainModels.Add(e.Adapt<TDomainModel>(this._typeAdapterConfig)));
        return domainModels;
    }

    public async Task<TDomainModel?> GetByIdAsync(TKey id)
    {
        var dataModel = await this._dataModelRepository.GetByIdAsync(id);
        return dataModel?.Adapt<TDomainModel>(this._typeAdapterConfig);
    }

    public async Task<TResult> MaxAsync<TResult>(Expression<Func<TDomainModel, TResult>> expression)
    {
        return await this._dataModelRepository.MaxAsync(expression.ConvertTo<TDomainModel, TDataModel, TResult>());
    }

    public async Task RemoveAsync(TKey id)
    {
        await this._dataModelRepository.RemoveAsync(id);
    }

    public async Task RemoveAsync(TDomainModel model)
    {
        await this._dataModelRepository.RemoveAsync(model.Id);
    }

    public async Task<TDomainModel> SaveAsync(TDomainModel model)
    {
        return await this.UpdateAsync(model);
    }

    public async Task<TDomainModel> UpdateAsync(TDomainModel model)
    {
        var dataModel = model.Adapt<TDataModel>(this._typeAdapterConfig);
        var result = await this._dataModelRepository.UpdateAsync(dataModel);
        return result.Adapt<TDomainModel>(this._typeAdapterConfig);
    }
    #endregion Methods
}
