using Microsoft.AspNetCore.Mvc;
using PMS.MicroServices.LuckyDraw.Service.Configurations;
using PMS.MicroServices.LuckyDraw.WebApi.Controllers.Base;

namespace PMS.MicroServices.LuckyDraw.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DocumentTemplateController : LuckyDrawControllerBase
{
    #region Constructors
    public DocumentTemplateController(LuckyDrawConfigurationLoader loader)
        : base(loader)
    {

    }
    #endregion Constructors
}
