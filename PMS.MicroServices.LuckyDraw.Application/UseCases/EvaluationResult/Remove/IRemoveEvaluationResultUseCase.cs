namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IRemoveEvaluationResultUseCase
{
    Task ExecuteAsync(Guid id, bool commit = false);
}
