using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOutSortitionUseCase
    : UseCaseBase, 
    IFindOutSortitionUseCase
{
    #region Constructors
    public FindOutSortitionUseCase(ISortitionResultDomainService sortitionResultDomainService)
    {
        this._sortitionResultDomainService = sortitionResultDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly ISortitionResultDomainService _sortitionResultDomainService;
    #endregion Fields

    #region Tasks
    public async Task<List<GeneralAssessmentUseCaseModel>> ExecuteAsync(string nickname, string userNameOrEmail, string code, string? evaluatedPersonName = null)
    {
        var domainModels = await this._sortitionResultDomainService.FindOutAsync(nickname, userNameOrEmail, code, evaluatedPersonName);
        var useCaseModels = new List<GeneralAssessmentUseCaseModel>(domainModels.Count);
        domainModels.OrderBy(m => m.Key).ToList().ForEach(e => useCaseModels.Add(e.Adapt<GeneralAssessmentUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Tasks
}
