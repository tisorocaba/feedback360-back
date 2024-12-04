namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IMakeRaffleUseCase
{
    Task<SortitionUseCaseModel?> ExecuteAsync(int rows, int columns = 3);
    Task<SortitionUseCaseModel?> ExecuteTeamAsync(Guid idTeam, int columns = 3);
}
