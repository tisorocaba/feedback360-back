namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddEvaluationResultUseCase
{
    Task<EvaluationResultUseCaseModel?> ExecuteAsync(EvaluationResultUseCaseModel? model, bool commit = false);
}
