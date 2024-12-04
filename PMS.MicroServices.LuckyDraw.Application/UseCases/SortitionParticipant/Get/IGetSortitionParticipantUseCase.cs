using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetSortitionParticipantUseCase
{
    Task<SortitionParticipantUseCaseModel?> ExecuteAsync(Guid id);
}
