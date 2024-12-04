using Mapster;
using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Application.Constants;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;

namespace PMS.MicroServices.LuckyDraw.Service.Configurations;

public class LuckyDrawConfigurationLoader
{
    #region Constructors
    public LuckyDrawConfigurationLoader(IConfiguration configuration)
    {
        this._configuration = configuration;
    }
    #endregion Constructors

    #region Fields
    readonly IConfiguration _configuration;
    #endregion Fields

    #region Methods
    public string GetCurrentAppSettingsValue(string currentAppSettingsKey)
    {
        return this._configuration.GetSection(currentAppSettingsKey.Trim())?.Value?.Trim() ?? string.Empty;
    }

    public LuckyDrawAppConfiguration Load()
    {
        var config = new LuckyDrawConfiguration();
        config.MailingFromAddress = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingFromAddressPath);
        config.MailingFromName = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingFromNamePath);
        config.MailingHost = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingHostPath);
        config.MailingPassword = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingPasswordPath);
        config.MailingPort = TypeUtility.ConvertToInteger(this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingPortPath));
        config.MailingSubject = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingSubjectPath);
        config.MailingUserName = this.GetCurrentAppSettingsValue(LuckyDrawApplicationConstants.AppSettingsMailingUserNamePath);
        return config.Adapt<LuckyDrawAppConfiguration>();
    }
    #endregion Methods
}
