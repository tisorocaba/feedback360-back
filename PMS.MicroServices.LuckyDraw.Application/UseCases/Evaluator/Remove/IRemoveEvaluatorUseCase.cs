namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IRemoveEvaluatorUseCase
{
    Task ExecuteAsync(Guid id, bool commit = false);
}
