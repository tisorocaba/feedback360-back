using Mapster;
using Microsoft.AspNetCore.Mvc;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;
using PMS.MicroServices.LuckyDraw.Service.AdapterConfigurations;
using PMS.MicroServices.LuckyDraw.Service.Configurations;

namespace PMS.MicroServices.LuckyDraw.WebApi.Controllers.Base;

[Route("api/[controller]")]
[ApiController]
public class LuckyDrawControllerBase : ControllerBase
{
    #region Constructors
    public LuckyDrawControllerBase(LuckyDrawConfigurationLoader loader)
    {
        this._luckyDrawConfigurationLoader = loader;
        this.AdapterConfig = ServiceModelAdapterConfiguration.GetAdapterConfig();
    }
    #endregion Constructors

    #region Fields
    public readonly TypeAdapterConfig AdapterConfig;
    LuckyDrawAppConfiguration _luckyDrawAppConfiguration = default!;
    readonly LuckyDrawConfigurationLoader _luckyDrawConfigurationLoader;
    #endregion Fields

    #region Methods
    [NonAction]
    public LuckyDrawAppConfiguration GetLuckyDrawConfiguration()
    {
        if (this._luckyDrawAppConfiguration == null)
            this._luckyDrawAppConfiguration = this._luckyDrawConfigurationLoader.Load();
        return this._luckyDrawAppConfiguration.Adapt<LuckyDrawAppConfiguration>();
    }
    #endregion Methods
}
