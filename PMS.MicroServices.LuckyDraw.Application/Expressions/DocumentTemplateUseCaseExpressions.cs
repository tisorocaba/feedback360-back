using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class DocumentTemplateUseCaseExpressions
{
    public static OrderByExpression<DocumentTemplateUseCaseModel, object> CreatedAtOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.CreatedAt
    };

    public static OrderByExpression<DocumentTemplateUseCaseModel, object> CreatedAtOrderByDescending = new()
    {
        Descending = true,
        OrderBy = x => x.CreatedAt
    };
}
