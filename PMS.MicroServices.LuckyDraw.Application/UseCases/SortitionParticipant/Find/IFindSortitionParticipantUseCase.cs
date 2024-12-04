using PMS.MicroServices.LuckyDraw.Application.Models;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindSortitionParticipantUseCase
{
    Task<List<SortitionParticipantUseCaseModel>> ExecuteAsync(Expression<Func<SortitionParticipantUseCaseModel, bool>> expression);
}
