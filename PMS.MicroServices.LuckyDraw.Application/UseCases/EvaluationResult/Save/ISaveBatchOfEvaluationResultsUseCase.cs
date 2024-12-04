namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveBatchOfEvaluationResultsUseCase
{
    Task ExecuteAsync(List<EvaluationResultUseCaseModel> list, bool commit = false);
}
