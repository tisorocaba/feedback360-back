namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllSortitionsUseCase
{
    Task<List<SortitionUseCaseModel>> ExecuteAsync();
}
