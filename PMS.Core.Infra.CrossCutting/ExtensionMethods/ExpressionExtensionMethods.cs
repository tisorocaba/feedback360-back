using PMS.Core.Infra.CrossCutting.Expressions;
using System.Linq.Expressions;

namespace PMS.Core.Infra.CrossCutting.ExtensionMethods;

public static class ExpressionExtensionMethods
{
    public static Expression<Func<T, TResult>> AndAlsoExpression<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
    {
        var paramExpr = Expression.Parameter(typeof(T));
        var andAlso = Expression.AndAlso(expr1.Body, expr2.Body);
        var replacedParam = new ParameterReplacer(paramExpr).Visit(andAlso);
        var binExpr = (BinaryExpression)replacedParam;
        var lambda = Expression.Lambda<Func<T, TResult>>(binExpr, paramExpr);
        return lambda;
    }

    public static Expression<Func<TOut, TResult>> ConvertTo<TIn, TOut, TResult>(this Expression<Func<TIn, TResult>> expr)
    {
        var param = Expression.Parameter(typeof(TOut));
        var body = new Visitor<TOut>(param).Visit(expr.Body);
        var lambda = Expression.Lambda<Func<TOut, TResult>>(body, param);
        return lambda;
    }

    public static Expression<Func<T, TResult>> OrElseExpression<T, TResult>(this Expression<Func<T, TResult>> expr1, Expression<Func<T, TResult>> expr2)
    {
        var paramExpr = Expression.Parameter(typeof(T));
        var orElse = Expression.OrElse(expr1.Body, expr2.Body);
        var replacedParam = new ParameterReplacer(paramExpr).Visit(orElse);
        var binExpr = (BinaryExpression)replacedParam;
        var lambda = Expression.Lambda<Func<T, TResult>>(binExpr, paramExpr);
        return lambda;
    }
}
