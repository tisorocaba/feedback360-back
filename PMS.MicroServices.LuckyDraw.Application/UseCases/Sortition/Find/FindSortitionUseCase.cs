using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindSortitionUseCase
    : UseCaseBase,
    IFindSortitionUseCase
{
    #region Constructors
    public FindSortitionUseCase(ISortitionDomainService sortitionDomainService)
    {
        this._sortitionDomainService = sortitionDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly ISortitionDomainService _sortitionDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<SortitionUseCaseModel>> ExecuteAsync(Expression<Func<SortitionUseCaseModel, bool>> expression)
    {
        OrderByExpression<SortitionUseCaseModel, object> numberOrderByDescending = SortitionUseCaseExpressions.NumberOrderByDescending;
        var domainModels = await this._sortitionDomainService.FindAsync(expression.ConvertTo<SortitionUseCaseModel, Sortition, bool>(),
                                                                        numberOrderByDescending.ConvertTo<SortitionUseCaseModel, Sortition, object>());
        var useCaseModels = new List<SortitionUseCaseModel>(domainModels.Count);
        domainModels.ForEach(e => useCaseModels.Add(e.Adapt<SortitionUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
