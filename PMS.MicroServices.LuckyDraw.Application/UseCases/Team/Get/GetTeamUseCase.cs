using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetTeamUseCase
    : UseCaseBase,
    IGetTeamUseCase
{
    #region Constructors
    public GetTeamUseCase(ITeamDomainService teamDomainService)
    {
        this._teamDomainService = teamDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly ITeamDomainService _teamDomainService;
    #endregion Fields

    #region Methods
    public async Task<TeamUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._teamDomainService.GetByIdAsync(id);
        return domainModel?.Adapt<TeamUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
