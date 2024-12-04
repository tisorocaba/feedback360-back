namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllNamesUseCase
{
    Task<List<NameUseCaseModel>> ExecuteAsync();
}
