namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddEvaluatorUseCase
{
    Task<EvaluatorUseCaseModel?> ExecuteAsync(EvaluatorUseCaseModel? model, bool commit = false);
}
