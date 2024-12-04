namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllEvaluatorsUseCase
{
    Task<List<EvaluatorUseCaseModel>> ExecuteAsync();
}
