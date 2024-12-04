namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllEvaluationResultsUseCase
{
    Task<List<EvaluationResultUseCaseModel>> ExecuteAsync();
}
