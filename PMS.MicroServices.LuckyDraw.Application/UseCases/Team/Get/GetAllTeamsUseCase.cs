using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllTeamsUseCase
    : UseCaseBase,
    IGetAllTeamsUseCase
{
    #region Constructors
    public GetAllTeamsUseCase(ITeamDomainService teamDomainService)
    {
        this._teamDomainService = teamDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly ITeamDomainService _teamDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<TeamUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<TeamUseCaseModel, object> orderByCreatedAt = TeamUseCaseExpressions.NameOrderByAscending;
        var domainModels = await this._teamDomainService.GetAllAsync(orderByCreatedAt.ConvertTo<TeamUseCaseModel, Team, object>());
        var useCaseModels = new List<TeamUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<TeamUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
