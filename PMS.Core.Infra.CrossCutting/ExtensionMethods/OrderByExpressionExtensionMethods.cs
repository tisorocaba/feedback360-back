using PMS.Core.Infra.CrossCutting.Expressions;

namespace PMS.Core.Infra.CrossCutting.ExtensionMethods;

public static class OrderByExpressionExtensionMethods
{
    public static OrderByExpression<TOut, TOrderBy?> ConvertTo<TIn, TOut, TOrderBy>(this OrderByExpression<TIn, TOrderBy> exp)
    {
        return new OrderByExpression<TOut, TOrderBy?>()
        {
            Descending = exp.Descending,
            OrderBy = exp.OrderBy.ConvertTo<TIn, TOut, TOrderBy?>()
        };
    }
}
