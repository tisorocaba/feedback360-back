namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllNickNamesUseCase
{
    Task<List<NickNameUseCaseModel>> ExecuteAsync();
}
