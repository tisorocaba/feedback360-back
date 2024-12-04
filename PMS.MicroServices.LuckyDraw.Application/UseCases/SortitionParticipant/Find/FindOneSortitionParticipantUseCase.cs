using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOneSortitionParticipantUseCase
    : UseCaseBase,
    IFindOneSortitionParticipantUseCase
{
    #region Constructors
    public FindOneSortitionParticipantUseCase(ISortitionParticipantDomainService sortitionParticipantDomainService)
    {
        this._sortitionParticipantDomainService = sortitionParticipantDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly ISortitionParticipantDomainService _sortitionParticipantDomainService;
    #endregion Fields

    #region Methods
    public async Task<SortitionParticipantUseCaseModel?> ExecuteAsync(Expression<Func<SortitionParticipantUseCaseModel, bool>> expression)
    {
        var domainModel = await this._sortitionParticipantDomainService.FindOneAsync(expression.ConvertTo<SortitionParticipantUseCaseModel, SortitionParticipant, bool>());
        return domainModel?.Adapt<SortitionParticipantUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
