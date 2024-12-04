namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddTeamUseCase
{
    Task ExecuteAsync(TeamUseCaseModel? model, bool commit = false);
}
