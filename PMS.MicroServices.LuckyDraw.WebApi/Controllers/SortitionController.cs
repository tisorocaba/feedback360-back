using Mapster;
using Microsoft.AspNetCore.Mvc;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Application.UseCases;
using PMS.MicroServices.LuckyDraw.Service.Configurations;
using PMS.MicroServices.LuckyDraw.Service.Constants;
using PMS.MicroServices.LuckyDraw.Service.Models;
using PMS.MicroServices.LuckyDraw.WebApi.Controllers.Base;

namespace PMS.MicroServices.LuckyDraw.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SortitionController : LuckyDrawControllerBase
{
    #region Constructors
    public SortitionController(LuckyDrawConfigurationLoader loader, IConsultSortitionParticipantUseCase consultSortitionParticipantUseCase,
                               IGetAllSortitionsUseCase getAllSortitionsUseCase, IGetSortitionUseCase getSortitionUseCase,
                               IMakeRaffleUseCase makeRaffleUseCase, ISaveSortitionUseCase saveSortitionUseCase)
        : base(loader)
    {
        this._consultSortitionParticipantUseCase = consultSortitionParticipantUseCase;
        this._getAllSortitionsUseCase = getAllSortitionsUseCase;
        this._getSortitionUseCase = getSortitionUseCase;
        this._makeRaffleUseCase = makeRaffleUseCase;
        this._saveSortitionUseCase = saveSortitionUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IConsultSortitionParticipantUseCase _consultSortitionParticipantUseCase;
    readonly IGetAllSortitionsUseCase _getAllSortitionsUseCase;
    readonly IGetSortitionUseCase _getSortitionUseCase;
    readonly IMakeRaffleUseCase _makeRaffleUseCase;
    readonly ISaveSortitionUseCase _saveSortitionUseCase;
    #endregion Fields

    #region Actions
    [HttpGet]
    public async Task<List<SortitionServiceModel>> GetAllAsync()
    {
        var useCaseModels = await this._getAllSortitionsUseCase.ExecuteAsync();
        var serviceModels = new List<SortitionServiceModel>(useCaseModels.Count());
        useCaseModels.ToList().ForEach(e => serviceModels.Add(e.Adapt<SortitionServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }

    [HttpGet(LuckyDrawServiceConstants.EndpointGetById)]
    public async Task<SortitionServiceModel?> GetByIdAsync(Guid id)
    {
        var useCaseModel = await this._getSortitionUseCase.ExecuteAsync(id);
        return useCaseModel?.Adapt<SortitionServiceModel>(this.AdapterConfig);
    }

    [HttpPost]
    public async Task PostAsync(SortitionServiceModel? model)
    {
        await this._saveSortitionUseCase.ExecuteAsync(model?.Adapt<SortitionUseCaseModel>(this.AdapterConfig), true);
    }

    [HttpPost(LuckyDrawServiceConstants.EndpointConsultAsync)]
    public async Task<SortitionConsultResponseMessage?> PostConsultAsync(SortitionConsultRequestMessage model)
    {
        return await this._consultSortitionParticipantUseCase.ExecuteAsync(model.ParticipantNumber, model.Code);
    }

    [HttpPost(LuckyDrawServiceConstants.EndpointTeamAsync)]
    public async Task<SortitionServiceModel?> PostTeamAsync(RaffleRequestMessage model)
    {
        var result = await this._makeRaffleUseCase.ExecuteTeamAsync(model.IdTeam);
        return result?.Adapt<SortitionServiceModel>(this.AdapterConfig);
    }

    [HttpPut]
    public async Task PutAsync(SortitionServiceModel? model)
    {
        await this._saveSortitionUseCase.ExecuteAsync(model?.Adapt<SortitionUseCaseModel>(this.AdapterConfig), true);
    }
    #endregion Actions
}
