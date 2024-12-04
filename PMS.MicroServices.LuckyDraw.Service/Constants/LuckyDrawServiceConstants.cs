namespace PMS.MicroServices.LuckyDraw.Service.Constants;

public class LuckyDrawServiceConstants
{
    // Endpoints
    public const string EndpointConsultAsync = "Consult";
    public const string EndpointDelete = "{id}";
    public const string EndpointGetById = "{id}";
    public const string EndpointGetEvaluatedNames = "Names";
    public const string EndpointGetNickNames = "NickNames";
    public const string EndpointTeamAsync = "Team";

    // General
    public const string ThisAppName = "Lucky Draw Web API";
    public const string WindowsServiceJsonAppSettings = "windowsservicesettings.json";
    public const string WindowsServiceStartingMessage = $"{ThisAppName} está iniciando...";
    public const string WindowsServiceStoppedMessage = $"{ThisAppName} parou.";
    public const string WindowsServiceStoppingMessage = $"{ThisAppName} está parando...";
    public const string WindowsServiceWorkingMessage = $"{ThisAppName} está funcionando...";

    // EnvironmentVariables
    public const string EnvironmentVariableConfigurationRepositoryUrl = "CONSUL_URL";
    public const string EnvironmentVariableConsulConfigurationEnabled = "LUCKY_DRAW_CONSUL_CONFIG_ENABLED";
    public const string EnvironmentVariableConsulConfigurationKey = "LUCKY_DRAW_CONSUL_CONFIG_KEY";
}
