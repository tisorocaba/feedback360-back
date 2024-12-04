using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class SortitionParticipantUseCaseExpressions
{
    public static OrderByExpression<SortitionParticipantUseCaseModel, object> AccessCounterOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.AccessCounter
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> AccessCounterOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.AccessCounter
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> CodeOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Code
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> CodeOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.Code
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> NumberOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Number
    };

    public static OrderByExpression<SortitionParticipantUseCaseModel, object> NumberOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.Number
    };
}
