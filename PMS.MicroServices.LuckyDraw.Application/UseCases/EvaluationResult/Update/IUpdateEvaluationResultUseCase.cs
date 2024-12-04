namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateEvaluationResultUseCase
{
    Task<EvaluationResultUseCaseModel?> ExecuteAsync(EvaluationResultUseCaseModel? model, bool commit = false);
}
