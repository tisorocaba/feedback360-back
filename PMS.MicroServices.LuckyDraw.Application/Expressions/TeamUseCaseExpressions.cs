using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class TeamUseCaseExpressions
{
    public static OrderByExpression<TeamUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<TeamUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<TeamUseCaseModel, object> NameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Name
    };
}
