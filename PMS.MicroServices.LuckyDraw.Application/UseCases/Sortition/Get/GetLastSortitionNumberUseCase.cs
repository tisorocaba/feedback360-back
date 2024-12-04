using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetLastSortitionNumberUseCase
    : IGetLastSortitionNumberUseCase
{
    #region Constructors
    public GetLastSortitionNumberUseCase(ISortitionDomainService sortitionDomainService)
    {
        this._sortitionDomainService = sortitionDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly ISortitionDomainService _sortitionDomainService;
    #endregion Fields

    #region Methods
    public async Task<int> ExecuteAsync()
    {
        return await this._sortitionDomainService.MaxAsync(e => e.Number);
    }
    #endregion Methods
}
