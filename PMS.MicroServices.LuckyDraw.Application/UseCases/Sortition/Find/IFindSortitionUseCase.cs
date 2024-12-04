using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindSortitionUseCase
{
    Task<List<SortitionUseCaseModel>> ExecuteAsync(Expression<Func<SortitionUseCaseModel, bool>> expression);
}
