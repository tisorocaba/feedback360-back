using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveSortitionUseCase
{
    Task<Sortition?> ExecuteAsync(Sortition? model, bool commit = false);
    Task<SortitionUseCaseModel?> ExecuteAsync(SortitionUseCaseModel? model, bool commit = false);
}
