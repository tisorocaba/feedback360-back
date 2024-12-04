using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindSortitionParticipantUseCase
    : UseCaseBase,
    IFindSortitionParticipantUseCase
{
    #region Constructors
    public FindSortitionParticipantUseCase(ISortitionParticipantDomainService sortitionParticipantDomainService)
    {
        this._sortitionParticipantDomainService = sortitionParticipantDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly ISortitionParticipantDomainService _sortitionParticipantDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<SortitionParticipantUseCaseModel>> ExecuteAsync(Expression<Func<SortitionParticipantUseCaseModel, bool>> expression)
    {
        OrderByExpression<SortitionParticipantUseCaseModel, object> numberOrderByDescending = SortitionParticipantUseCaseExpressions.NumberOrderByDescending;
        var domainModels = await this._sortitionParticipantDomainService.FindAsync(expression.ConvertTo<SortitionParticipantUseCaseModel, SortitionParticipant, bool>(),
                                                                                   numberOrderByDescending.ConvertTo<SortitionParticipantUseCaseModel, SortitionParticipant, object>());
        var useCaseModels = new List<SortitionParticipantUseCaseModel>(domainModels.Count);
        domainModels.ForEach(e => useCaseModels.Add(e.Adapt<SortitionParticipantUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
