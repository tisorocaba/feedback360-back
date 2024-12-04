using Mapster;
using Microsoft.AspNetCore.Mvc;
using PMS.MicroServices.LuckyDraw.Application.UseCases;
using PMS.MicroServices.LuckyDraw.Service.Configurations;
using PMS.MicroServices.LuckyDraw.Service.Constants;
using PMS.MicroServices.LuckyDraw.Service.Models;
using PMS.MicroServices.LuckyDraw.WebApi.Controllers.Base;

namespace PMS.MicroServices.LuckyDraw.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamController : LuckyDrawControllerBase
{
    #region Constructors
    public TeamController(LuckyDrawConfigurationLoader loader, IGetAllTeamsUseCase getAllTeamsUseCase, IGetTeamUseCase getTeamUseCase, IRemoveTeamUseCase removeTeamUseCase,
                          ISaveTeamUseCase saveTeamUseCase)
        : base(loader)
    {
        this._getAllTeamsUseCase = getAllTeamsUseCase;
        this._getTeamUseCase = getTeamUseCase;
        this._removeTeamUseCase = removeTeamUseCase;
        this._saveTeamUseCase = saveTeamUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllTeamsUseCase _getAllTeamsUseCase;
    readonly IGetTeamUseCase _getTeamUseCase;
    readonly IRemoveTeamUseCase _removeTeamUseCase;
    readonly ISaveTeamUseCase _saveTeamUseCase;
    #endregion Fields

    #region Actions
    [HttpDelete(LuckyDrawServiceConstants.EndpointDelete)]
    public async Task DeleteAsync(Guid id)
    {
        await this._removeTeamUseCase.ExecuteAsync(id);
    }

    [HttpGet]
    public async Task<List<TeamServiceModel>> GetAllAsync()
    {
        var useCaseModels = await this._getAllTeamsUseCase.ExecuteAsync();
        var serviceModels = new List<TeamServiceModel>(useCaseModels.Count());
        useCaseModels.ToList().ForEach(e => serviceModels.Add(e.Adapt<TeamServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }

    [HttpGet(LuckyDrawServiceConstants.EndpointGetById)]
    public async Task<TeamServiceModel?> GetByIdAsync(Guid id)
    {
        var useCaseModel = await this._getTeamUseCase.ExecuteAsync(id);
        return useCaseModel?.Adapt<TeamServiceModel>(this.AdapterConfig);
    }

    [HttpPost]
    public async Task PostAsync(TeamServiceModel? model)
    {
        await this._saveTeamUseCase.ExecuteAsync(model?.Adapt<TeamUseCaseModel>(this.AdapterConfig), true);
    }

    [HttpPut]
    public async Task PutAsync(TeamServiceModel? model)
    {
        await this._saveTeamUseCase.ExecuteAsync(model?.Adapt<TeamUseCaseModel>(this.AdapterConfig), true);
    }
    #endregion Actions
}
