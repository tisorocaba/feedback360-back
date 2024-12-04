using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.Core.Domain.Repositories.Interfaces;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.Utilities;
using System.Linq.Expressions;

namespace PMS.Core.Domain.DomainServices.Base;

public abstract class DomainServiceBase<TDomainModel, TKey>
    : IDomainService<TDomainModel, TKey>
    where TDomainModel : DomainModelBase<TKey>, new()
{
    #region Constructors
    protected DomainServiceBase(IRepository<TDomainModel, TKey> repository)
    {
        this._repository = repository;
    }
    #endregion Constructors

    #region Fields
    readonly IRepository<TDomainModel, TKey> _repository;
    #endregion Fields

    #region Methods
    public virtual async Task<List<TDomainModel>> FindAsync(Expression<Func<TDomainModel, bool>> expression, params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        return await this._repository.FindAsync(expression, orderByExpressions);
    }

    public virtual async Task<TDomainModel?> FindOneAsync(Expression<Func<TDomainModel, bool>> expression)
    {
        return await this._repository.FindOneAsync(expression);
    }

    public virtual async Task<List<TDomainModel>> GetAllAsync(params OrderByExpression<TDomainModel, object?>[] orderByExpressions)
    {
        return await this._repository.GetAllAsync(orderByExpressions);
    }

    public virtual async Task<TDomainModel?> GetByIdAsync(TKey id)
    {
        return await this._repository.GetByIdAsync(id);
    }

    public async Task<TResult> MaxAsync<TResult>(Expression<Func<TDomainModel, TResult>> expression)
    {
        return await this._repository.MaxAsync(expression);
    }

    public async Task RemoveAsync(TKey id)
    {
        if (!TypeUtility.IsSetByDefault(id))
            await this._repository.RemoveAsync(id);
    }

    public async Task RemoveAsync(TDomainModel model)
    {
        await this.RemoveAsync(model.Id);
    }

    public virtual async Task<TDomainModel?> SaveAsync(TDomainModel model)
    {
        if (model != null)
        {
            bool hasEmptyKey = model.HasEmptyKey;
            bool isPrepared = model.PrepareForAddingOrUpdate();
            if (isPrepared)
            {
                if (hasEmptyKey)
                    return await this._repository.AddAsync(model);
                else
                    return await this._repository.UpdateAsync(model);
            }
            else
                return model;
        }
        return null;
    }
    #endregion Methods

    #region Properties
    protected IRepository<TDomainModel, TKey> Repository { get { return this._repository; } }
    #endregion Properties
}
