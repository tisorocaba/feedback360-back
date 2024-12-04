using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class EvaluatorUseCaseExpressions
{
    public static OrderByExpression<EvaluatorUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<EvaluatorUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<EvaluatorUseCaseModel, object> NameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Name
    };

    public static OrderByExpression<EvaluatorUseCaseModel, object> NickNameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.NickName
    };
}
