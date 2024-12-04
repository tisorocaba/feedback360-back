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
public class ResultController : LuckyDrawControllerBase
{
    #region Constructors
    public ResultController(LuckyDrawConfigurationLoader loader, IFindNameUseCase findNameUseCase, IFindOutSortitionUseCase findOutSortitionUseCase, 
                            IGetAllNamesUseCase getAllNamesUseCase, IGetAllNickNamesUseCase getAllNickNamesUseCase)
        : base(loader)
    {
        this._findNameUseCase = findNameUseCase;
        this._findOutSortitionUseCase = findOutSortitionUseCase;
        this._getAllNamesUseCase = getAllNamesUseCase;
        this._getAllNickNamesUseCase = getAllNickNamesUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IFindNameUseCase _findNameUseCase;
    readonly IFindOutSortitionUseCase _findOutSortitionUseCase;
    readonly IGetAllNamesUseCase _getAllNamesUseCase;
    readonly IGetAllNickNamesUseCase _getAllNickNamesUseCase;
    #endregion Fields

    #region Actions
    [HttpGet(LuckyDrawServiceConstants.EndpointGetEvaluatedNames)]
    public async Task<List<NameServiceModel>> GetAllEvaluatedNamesAsync()
    {
        var useCaseModels = await this._getAllNamesUseCase.ExecuteAsync();
        var serviceModels = new List<NameServiceModel>(useCaseModels.Count());
        useCaseModels.ToList().ForEach(e => serviceModels.Add(e.Adapt<NameServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }

    [HttpGet(LuckyDrawServiceConstants.EndpointGetNickNames)]
    public async Task<List<NickNameServiceModel>> GetAllNickNamesAsync()
    {
        var useCaseModels = await this._getAllNickNamesUseCase.ExecuteAsync();
        var serviceModels = new List<NickNameServiceModel>(useCaseModels.Count());
        useCaseModels.ToList().ForEach(e => serviceModels.Add(e.Adapt<NickNameServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }

    [HttpPost]
    public async Task<List<GeneralAssessmentServiceModel>> PostAsync(AssessmentResultRequestMessage model)
    {
        var useCaseModels = await this._findOutSortitionUseCase.ExecuteAsync(model.NickName, model.UserNameOrEmail, model.Code, model.EvaluatedPersonName);
        var serviceModels = new List<GeneralAssessmentServiceModel>(useCaseModels.Count());
        useCaseModels.OrderBy(x => x.Key).ToList().ForEach(e => serviceModels.Add(e.Adapt<GeneralAssessmentServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }
    #endregion Actions
}
