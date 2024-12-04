using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOneAssessmentResultUseCase
{
    Task<AssessmentResultUseCaseModel?> ExecuteAsync(Expression<Func<AssessmentResultUseCaseModel, bool>> expression);
}
