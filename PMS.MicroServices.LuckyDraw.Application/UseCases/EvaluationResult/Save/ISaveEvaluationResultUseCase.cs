namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveEvaluationResultUseCase
{
    Task<EvaluationResultUseCaseModel?> ExecuteAsync(EvaluationResultUseCaseModel? model, bool commit = false);
}
