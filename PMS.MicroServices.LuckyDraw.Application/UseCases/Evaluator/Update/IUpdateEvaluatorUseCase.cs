namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateEvaluatorUseCase
{
    Task<EvaluatorUseCaseModel?> ExecuteAsync(EvaluatorUseCaseModel? model, bool commit = false);
}
