namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IRemoveTeamUseCase
{
    Task ExecuteAsync(Guid id, bool commit = false);
}
