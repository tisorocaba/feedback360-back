using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.DataModels.Base;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using System.Linq.Expressions;

namespace PMS.Core.Infra.Data.EFCore.Repositories.Base;

public abstract class EFCoreDataModelRepositoryBase<TDataModel, TKey>
    : IEFCoreDataModelRepository<TDataModel, TKey>
    where TDataModel : DataModelBase<TKey>
{
    #region Constructors
    public EFCoreDataModelRepositoryBase(IDbContext context)
    {
        this._context = context;
        this._dbSet = this._context.Set<TDataModel>();
    }
    #endregion Constructors

    #region Fields
    private readonly IDbContext _context;
    private readonly DbSet<TDataModel> _dbSet;
    #endregion Fields

    #region Methods
    public async Task<TDataModel> AddAsync(TDataModel model)
    {
        var entry = await this._dbSet.AddAsync(model);
        return entry.Entity;
    }

    private IQueryable<TDataModel> ApplyOrderBy<TOrderBy>(IQueryable<TDataModel> queryable, OrderByExpression<TDataModel, TOrderBy>? orderByExpression = null)
    {
        if ((orderByExpression != null) && (orderByExpression.OrderBy != null))
        {
            if (orderByExpression.Descending)
                return queryable.OrderByDescending(orderByExpression.OrderBy);
            else
                return queryable.OrderBy(orderByExpression.OrderBy);
        }
        return queryable;
    }

    private IQueryable<TDataModel> ApplyOrderByArray<TOrderBy>(IQueryable<TDataModel> queryable, OrderByExpression<TDataModel, TOrderBy>[] orderByExpressions)
    {
        if (orderByExpressions?.Any() ?? false)
        {
            if (orderByExpressions.Length == 1)
                queryable = ApplyOrderBy(queryable, orderByExpressions[0]);
            else
            {
                IOrderedQueryable<TDataModel>? orderedQueryable = null;
                for (int currentIndex = 0; currentIndex < orderByExpressions.Length; currentIndex++)
                {
                    var currentOrderByExpression = orderByExpressions[currentIndex];
                    if (currentOrderByExpression?.OrderBy != null)
                    {
                        if (currentIndex == 0)
                        {
                            if (currentOrderByExpression.Descending)
                                orderedQueryable = queryable.OrderByDescending(currentOrderByExpression.OrderBy);
                            else
                                orderedQueryable = queryable.OrderBy(currentOrderByExpression.OrderBy);
                        }
                        else
                        {
                            if (currentOrderByExpression.Descending)
                                orderedQueryable = orderedQueryable?.ThenByDescending(currentOrderByExpression.OrderBy);
                            else
                                orderedQueryable = orderedQueryable?.ThenBy(currentOrderByExpression.OrderBy);
                        }
                    }
                }
                queryable = orderedQueryable ?? queryable;
            }
        }
        return queryable;
    }

    public async Task<List<TDataModel>> FindAsync(Expression<Func<TDataModel, bool>> whereExpression, params OrderByExpression<TDataModel, object?>[] orderByExpressions)
    {
        var queryable = this._dbSet.Where(whereExpression);
        queryable = this.ApplyOrderByArray(queryable, orderByExpressions);
        return await queryable.ToListAsync();
    }

    public async Task<TDataModel?> FindOneAsync(Expression<Func<TDataModel, bool>> whereExpression)
    {
        var queryable = this._dbSet.Where(whereExpression);
        return await queryable.FirstOrDefaultAsync();
    }

    public async Task<List<TDataModel>> GetAllAsync(params OrderByExpression<TDataModel, object?>[] orderByExpressions)
    {
        var queryable = this._dbSet.AsQueryable();
        queryable = this.ApplyOrderByArray(queryable, orderByExpressions);
        return await queryable.ToListAsync();
    }

    public async Task<TDataModel?> GetByIdAsync(TKey id)
    {
        if (TypeUtility.IsSetByDefault(id))
            return await Task.FromResult(ReflectionUtility.Instantiate<TDataModel>());
        var result = await this._dbSet.FirstOrDefaultAsync(x => (x != null) && Equals(x.Id, id));
        return result;
    }

    public async Task<TResult> MaxAsync<TResult>(Expression<Func<TDataModel, TResult>> expression)
    {
        try { return await this._dbSet.MaxAsync(expression); }
        catch { return TypeUtility.ConvertTo<TResult>(0); }
    }

    public async Task RemoveAsync(TKey id)
    {
        TDataModel? dataModel = await this.GetByIdAsync(id);
        if (dataModel == null)
        {
            dataModel = ReflectionUtility.Instantiate<TDataModel>();
            dataModel.Id = id;
        }
        await this.RemoveAsync(dataModel);
    }

    public async Task RemoveAsync(TDataModel? dataModel)
    {
        if (dataModel != null)
            this._dbSet.Remove(dataModel);
        await Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(params TDataModel[] range)
    {
        this._dbSet.RemoveRange(range);
        await Task.CompletedTask;
    }

    public async Task<TDataModel> UpdateAsync(TDataModel dataModel)
    {
        var model = await this._dbSet.FirstOrDefaultAsync(m => object.Equals(m.Id, dataModel.Id)) ?? dataModel;
        ReflectionUtility.CopyTo(dataModel, model);
        var result = this._dbSet.Update(model);
        return await Task.FromResult(result.Entity);
    }
    #endregion Methods

    #region Properties
    public IDbContext Context { get { return this._context; } }
    public DbSet<TDataModel> DbSet { get { return this._dbSet; } }
    #endregion Properties
}
