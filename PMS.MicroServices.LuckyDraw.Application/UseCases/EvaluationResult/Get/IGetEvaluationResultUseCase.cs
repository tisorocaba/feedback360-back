namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetEvaluationResultUseCase
{
    Task<EvaluationResultUseCaseModel?> ExecuteAsync(Guid id);
}
