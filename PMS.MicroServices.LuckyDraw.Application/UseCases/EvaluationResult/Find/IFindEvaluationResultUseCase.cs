using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindEvaluationResultUseCase
{
    Task<List<EvaluationResultUseCaseModel>> ExecuteAsync(Expression<Func<EvaluationResultUseCaseModel, bool>> expression);
}
