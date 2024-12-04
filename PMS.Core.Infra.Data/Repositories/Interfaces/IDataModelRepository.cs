using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.Data.DataModels.Base;
using System.Linq.Expressions;

namespace PMS.Core.Infra.Data.Repositories.Interfaces;

public interface IDataModelRepository<TDataModel, TKey>
    where TDataModel : DataModelBase<TKey>
{
    #region Methods
    Task<TDataModel> AddAsync(TDataModel dataModel);
    Task<List<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> whereExpression, params OrderByExpression<TDataModel, object?>[] orderByExpressions);
    Task<TDataModel?> FindOneAsync(Expression<Func<TDataModel, bool>> whereExpression);
    Task<List<TDataModel>> GetAllAsync(params OrderByExpression<TDataModel, object?>[] orderByExpressions);
    Task<TDataModel?> GetByIdAsync(TKey id);
    Task<TResult> MaxAsync<TResult>(Expression<Func<TDataModel, TResult>> expression);
    Task RemoveAsync(TKey id);
    Task RemoveAsync(TDataModel? dataModel);
    Task<TDataModel> UpdateAsync(TDataModel dataModel);
    #endregion Methods
}
