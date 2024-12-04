using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllSortitionsUseCase
    : UseCaseBase,
    IGetAllSortitionsUseCase
{
    #region Constructors
    public GetAllSortitionsUseCase(ISortitionDomainService sortitionDomainService)
    {
        this._sortitionDomainService = sortitionDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionDomainService _sortitionDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<SortitionUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<SortitionUseCaseModel, object> numberOrderByDescending = SortitionUseCaseExpressions.NumberOrderByDescending;
        var domainModels = await this._sortitionDomainService.GetAllAsync(numberOrderByDescending.ConvertTo<SortitionUseCaseModel, Sortition, object>());
        var useCaseModels = new List<SortitionUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<SortitionUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
