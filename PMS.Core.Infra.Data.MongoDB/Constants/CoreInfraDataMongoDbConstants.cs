namespace PMS.Core.Infra.Data.MongoDB.Constants;

public class CoreInfraDataMongoDbConstants
{
    public const string AppSettingsMongoDb = "MongoDB";
    public const string AppSettingsMongoDbConnectionString = $"{AppSettingsMongoDb}:ConnectionString";
    public const string AppSettingsMongoDbDatabaseName = $"{AppSettingsMongoDb}:DatabaseName";
    public const string AppSettingsMongoDbHost = $"{AppSettingsMongoDb}:Host";
    public const string AppSettingsMongoDbPort = $"{AppSettingsMongoDb}:Port";
    public const string AppSettingsMongoDbUserName = $"{AppSettingsMongoDb}:UserName";
    public const string AppSettingsMongoDbPassword = $"{AppSettingsMongoDb}:Password";

    public const string CreatedAtAttributeName = "Carimbo de datahora";
    public const string IdAttributeName = "_id";
}
