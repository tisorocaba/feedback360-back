namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetTeamUseCase
{
    Task<TeamUseCaseModel?> ExecuteAsync(Guid id);
}
