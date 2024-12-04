using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetSortitionParticipantUseCase
    : UseCaseBase,
    IGetSortitionParticipantUseCase
{
    #region Constructors
    public GetSortitionParticipantUseCase(ISortitionParticipantDomainService sortitionParticipantDomainService)
    {
        this._sortitionParticipantDomainService = sortitionParticipantDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionParticipantDomainService _sortitionParticipantDomainService;
    #endregion Fields

    #region Methods
    public async Task<SortitionParticipantUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._sortitionParticipantDomainService.GetByIdAsync(id);
        return domainModel?.Adapt<SortitionParticipantUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
