using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IConsultSortitionParticipantUseCase
{
    Task<SortitionConsultResponseMessage?> ExecuteAsync(int participantNumber, string code, int? sortitionNumber = null, Guid? idTeam = null, bool commit = true);
}
