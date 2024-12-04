namespace PMS.MicroServices.LuckyDraw.Application.Constants;

public class LuckyDrawApplicationConstants
{
    // Application
    public const string CodeWorkspace = "§§%%$$CODE$$%%§§";
    public const string EmailWorkspace = "§§%%$$EMAIL$$%%§§";
    public const string NameWorkspace = "§§%%$$NAME$$%%§§";
    public const string TargetUrlWorkspace = "§§%%$$TARGET_URL$$%%§§";

    // Mailing
    public const string AppSettingsMailingPath = "Mailing";
    public const string AppSettingsMailingFromAddressPath = $"{AppSettingsMailingPath}:FromAddress";
    public const string AppSettingsMailingFromNamePath = $"{AppSettingsMailingPath}:FromName";
    public const string AppSettingsMailingHostPath = $"{AppSettingsMailingPath}:Host";
    public const string AppSettingsMailingPasswordPath = $"{AppSettingsMailingPath}:Password";
    public const string AppSettingsMailingPortPath = $"{AppSettingsMailingPath}:Port";
    public const string AppSettingsMailingSubjectPath = $"{AppSettingsMailingPath}:Subject";
    public const string AppSettingsMailingUserNamePath = $"{AppSettingsMailingPath}:UserName";

    // RabbitMQ
    public const string AppSettingsRabbitMQ = "RabbitMQ";
    public const string AppSettingsRabbitMQClientProvidedName = $"{AppSettingsRabbitMQ}:ClientProvidedName";
    public const string AppSettingsRabbitMQHostName = $"{AppSettingsRabbitMQ}:HostName";
    public const string AppSettingsRabbitMQPort = $"{AppSettingsRabbitMQ}:Port";
    public const string AppSettingsRabbitMQUserName = $"{AppSettingsRabbitMQ}:UserName";
    public const string AppSettingsRabbitMQPassword = $"{AppSettingsRabbitMQ}:Password";
    public const string AppSettingsRabbitMQVirtualHost = $"{AppSettingsRabbitMQ}:VirtualHost";
    public const string AppSettingsRabbitMQDispatchConsumersAsync = $"{AppSettingsRabbitMQ}:DispatchConsumersAsync";
    public const string AppSettingsRabbitMQAutoConnect = $"{AppSettingsRabbitMQ}:AutoConnect";
    public const string AppSettingsRabbitMQAutomaticRecoveryEnabled = $"{AppSettingsRabbitMQ}:AutomaticRecoveryEnabled";
    public const string AppSettingsRabbitMQNetworkRecoveryIntervalSeconds = $"{AppSettingsRabbitMQ}:NetworkRecoveryIntervalSeconds";
    public const string AppSettingsRabbitMQTopologyRecoveryEnabled = $"{AppSettingsRabbitMQ}:TopologyRecoveryEnabled";
    public const string AppSettingsRabbitMQRequestedHeartbeatSeconds = $"{AppSettingsRabbitMQ}:RequestedHeartbeatSeconds";
    public const string AppSettingsRabbitMQQueues = $"{AppSettingsRabbitMQ}:Queues";
    public const string AppSettingsRabbitMQQueuesAction = $"{AppSettingsRabbitMQQueues}:Action";
    public const string AppSettingsRabbitMQQueuesName = $"{AppSettingsRabbitMQQueues}:Name";
    public const string AppSettingsRabbitMQQueuesEnabled = $"{AppSettingsRabbitMQQueues}:Enabled";
    public const string AppSettingsRabbitMQEnabled = $"{AppSettingsRabbitMQ}:Enabled";
}
