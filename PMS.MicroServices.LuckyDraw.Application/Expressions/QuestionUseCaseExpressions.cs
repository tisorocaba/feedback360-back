using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class QuestionUseCaseExpressions
{
    public static OrderByExpression<QuestionUseCaseModel, object> AbbreviationOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Abbreviation
    };

    public static OrderByExpression<QuestionUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<QuestionUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };
}
