using Mapster;
using PMS.MicroServices.LuckyDraw.Application.AdapterConfigurations;

namespace PMS.MicroServices.LuckyDraw.Application.Base;

public abstract class UseCaseBase
{
    #region Constructors
    public UseCaseBase()
    {
        this.AdapterConfig = UseCaseModelAdapterConfiguration.GetAdapterConfig();
    }
    #endregion Constructors

    #region Fields
    public readonly TypeAdapterConfig AdapterConfig;
    #endregion Fields
}
