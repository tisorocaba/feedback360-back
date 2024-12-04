using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateSortitionParticipantUseCase
{
    Task<SortitionParticipant?> ExecuteAsync(SortitionParticipant? model, bool commit = false);
    Task<SortitionParticipantUseCaseModel?> ExecuteAsync(SortitionParticipantUseCaseModel? model, bool commit = false);
}
