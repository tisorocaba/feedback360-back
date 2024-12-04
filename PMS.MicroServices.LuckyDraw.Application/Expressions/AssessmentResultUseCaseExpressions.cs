using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class AssessmentResultUseCaseExpressions
{
    public static OrderByExpression<AssessmentResultUseCaseModel, object> EmailOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Email
    };

    public static OrderByExpression<AssessmentResultUseCaseModel, object> NameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Name
    };
}
