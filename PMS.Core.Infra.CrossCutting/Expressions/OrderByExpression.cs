using System.Linq.Expressions;

namespace PMS.Core.Infra.CrossCutting.Expressions;

public class OrderByExpression<TModel, TOrderBy>
{
    #region Methods
    public bool Descending { get; set; }
    public Expression<Func<TModel, TOrderBy?>> OrderBy { get; set; } = default!;
    #endregion Methods
}
