namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetSortitionUseCase
{
    Task<SortitionUseCaseModel?> ExecuteAsync(Guid id);
}
