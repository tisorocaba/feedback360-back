namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveEvaluatorUseCase
{
    Task<EvaluatorUseCaseModel?> ExecuteAsync(EvaluatorUseCaseModel? model, bool commit = false);
}
