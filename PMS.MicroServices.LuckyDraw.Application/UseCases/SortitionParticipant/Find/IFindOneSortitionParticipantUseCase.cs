using PMS.MicroServices.LuckyDraw.Application.Models;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOneSortitionParticipantUseCase
{
    Task<SortitionParticipantUseCaseModel?> ExecuteAsync(Expression<Func<SortitionParticipantUseCaseModel, bool>> expression);
}
