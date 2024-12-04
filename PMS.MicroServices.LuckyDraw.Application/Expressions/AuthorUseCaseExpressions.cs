using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.Expressions;

public class AuthorUseCaseExpressions
{
    public static OrderByExpression<AuthorUseCaseModel, object> NameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.Name
    };

    public static OrderByExpression<AuthorUseCaseModel, object> NickNameOrderByAscending = new()
    {
        Descending = false,
        OrderBy = x => x.NickName
    };
}
