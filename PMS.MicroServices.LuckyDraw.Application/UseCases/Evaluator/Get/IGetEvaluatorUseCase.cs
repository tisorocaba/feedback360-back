namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetEvaluatorUseCase
{
    Task<EvaluatorUseCaseModel?> ExecuteAsync(Guid id);
}
