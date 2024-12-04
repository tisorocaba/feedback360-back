using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class SortitionUseCaseExpressions
{
    public static OrderByExpression<SortitionUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<SortitionUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<SortitionUseCaseModel, object> NumberOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Number
    };

    public static OrderByExpression<SortitionUseCaseModel, object> NumberOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.Number
    };
}
