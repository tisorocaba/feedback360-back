using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveSortitionParticipantUseCase
{
    Task ExecuteAsync(SortitionParticipant? model, bool commit = false);
    Task ExecuteAsync(SortitionParticipantUseCaseModel? model, bool commit = false);
}
