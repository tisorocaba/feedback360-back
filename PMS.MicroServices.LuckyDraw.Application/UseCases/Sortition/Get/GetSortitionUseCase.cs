using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetSortitionUseCase
    : UseCaseBase,
    IGetSortitionUseCase
{
    #region Constructors
    public GetSortitionUseCase(ISortitionDomainService sortitionDomainService)
    {
        this._sortitionDomainService = sortitionDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionDomainService _sortitionDomainService;
    #endregion Fields

    #region Methods
    public async Task<SortitionUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._sortitionDomainService.GetByIdAsync(id);
        return domainModel?.Adapt<SortitionUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
