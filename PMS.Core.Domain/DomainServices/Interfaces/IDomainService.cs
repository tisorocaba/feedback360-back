using PMS.Core.Domain.DomainModels.Base;
using PMS.Core.Infra.CrossCutting.Expressions;
using System.Linq.Expressions;

namespace PMS.Core.Domain.DomainServices.Interfaces;

public interface IDomainService<TDomainModel, TKey>
    where TDomainModel : DomainModelBase<TKey>
{
    #region Methods
    Task<List<TDomainModel>> FindAsync(Expression<Func<TDomainModel, bool>> expression, params OrderByExpression<TDomainModel, object?>[] orderByExpressions);
    Task<TDomainModel?> FindOneAsync(Expression<Func<TDomainModel, bool>> expression);
    Task<List<TDomainModel>> GetAllAsync(params OrderByExpression<TDomainModel, object?>[] orderByExpressions);
    Task<TDomainModel?> GetByIdAsync(TKey id);
    Task<TResult> MaxAsync<TResult>(Expression<Func<TDomainModel, TResult>> expression);
    Task RemoveAsync(TKey id);
    Task RemoveAsync(TDomainModel model);
    Task<TDomainModel?> SaveAsync(TDomainModel model);
    #endregion Methods
}
