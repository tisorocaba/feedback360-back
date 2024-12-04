using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindEvaluatorUseCase
{
    Task<List<EvaluatorUseCaseModel>> ExecuteAsync(Expression<Func<EvaluatorUseCaseModel, bool>> expression);
}
