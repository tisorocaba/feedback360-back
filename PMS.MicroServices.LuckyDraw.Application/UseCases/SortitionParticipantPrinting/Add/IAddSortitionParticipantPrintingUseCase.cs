using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddSortitionParticipantPrintingUseCase
{
    Task ExecuteAsync(SortitionParticipantPrinting? model, bool commit = false);
    Task ExecuteAsync(SortitionParticipantPrintingUseCaseModel? model, bool commit = false);
}
