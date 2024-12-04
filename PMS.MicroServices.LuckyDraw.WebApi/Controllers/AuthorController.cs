using Mapster;
using Microsoft.AspNetCore.Mvc;
using PMS.MicroServices.LuckyDraw.Application.UseCases;
using PMS.MicroServices.LuckyDraw.Service.Configurations;
using PMS.MicroServices.LuckyDraw.Service.Models;
using PMS.MicroServices.LuckyDraw.WebApi.Controllers.Base;

namespace PMS.MicroServices.LuckyDraw.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController : LuckyDrawControllerBase
{
    #region Constructors
    public AuthorController(LuckyDrawConfigurationLoader loader, IGetAllAuthorsUseCase getAllAuthorsUseCase)
        : base(loader)
    {
        this._getAllAuthorsUseCase = getAllAuthorsUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllAuthorsUseCase _getAllAuthorsUseCase;
    #endregion Fields

    #region Actions
    [HttpGet]
    public async Task<List<AuthorServiceModel>> GetAllAsync()
    {
        var useCaseModels = await this._getAllAuthorsUseCase.ExecuteAsync();
        var serviceModels = new List<AuthorServiceModel>(useCaseModels.Count());
        useCaseModels.ToList().ForEach(e => serviceModels.Add(e.Adapt<AuthorServiceModel>(this.AdapterConfig)));
        return serviceModels;
    }
    #endregion Actions
}
