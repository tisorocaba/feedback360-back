namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveTeamUseCase
{
    Task ExecuteAsync(TeamUseCaseModel? model, bool commit = false);
}
