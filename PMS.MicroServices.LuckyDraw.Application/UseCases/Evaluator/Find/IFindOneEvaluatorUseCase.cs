using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOneEvaluatorUseCase
{
    Task<EvaluatorUseCaseModel?> ExecuteAsync(Expression<Func<EvaluatorUseCaseModel, bool>> expression);
}
