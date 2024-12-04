namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateTeamUseCase
{
    Task ExecuteAsync(TeamUseCaseModel? model, bool commit = false);
}
