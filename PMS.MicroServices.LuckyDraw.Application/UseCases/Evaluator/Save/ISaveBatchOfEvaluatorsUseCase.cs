namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveBatchOfEvaluatorsUseCase
{
    Task ExecuteAsync(List<EvaluatorUseCaseModel> list, bool commit = false);
}
