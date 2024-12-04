using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOneEvaluationResultUseCase
{
    Task<EvaluationResultUseCaseModel?> ExecuteAsync(Expression<Func<EvaluationResultUseCaseModel, bool>> expression);
}
