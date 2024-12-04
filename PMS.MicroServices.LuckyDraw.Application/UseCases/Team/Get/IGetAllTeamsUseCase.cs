namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllTeamsUseCase
{
    Task<List<TeamUseCaseModel>> ExecuteAsync();
}
