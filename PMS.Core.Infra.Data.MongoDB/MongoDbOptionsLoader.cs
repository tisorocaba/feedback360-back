using Microsoft.Extensions.Configuration;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.Core.Infra.Data.MongoDB.Models;

namespace PMS.Core.Infra.Data.MongoDB;

public class MongoDbOptionsLoader
{
    #region Constructors
    public MongoDbOptionsLoader(IConfiguration configuration)
    {
        this._configuration = configuration;
        this.DatabaseName = this._configuration?.GetSection(CoreInfraDataMongoDbConstants.AppSettingsMongoDbDatabaseName)?.Value ?? string.Empty;
        this.Host = this._configuration?.GetSection(CoreInfraDataMongoDbConstants.AppSettingsMongoDbHost)?.Value;
        this.Port = TypeUtility.ConvertToNullableOfInteger(this._configuration?.GetSection(CoreInfraDataMongoDbConstants.AppSettingsMongoDbPort)?.Value);
        this.Password = this._configuration?.GetSection(CoreInfraDataMongoDbConstants.AppSettingsMongoDbPassword)?.Value;
        this.UserName = this._configuration?.GetSection(CoreInfraDataMongoDbConstants.AppSettingsMongoDbUserName)?.Value;
    }
    #endregion Constructors

    #region Methods
    public MongoDbOptions ToOptions()
    {
        return new MongoDbOptions(this.ConnectionString, this.DatabaseName, null, null);
    }
    #endregion Methods

    #region Fields
    private readonly IConfiguration? _configuration;
    #endregion Fields

    #region Properties
    public string ConnectionString { get { return $@"mongodb://{UserName ?? string.Empty}:{Password ?? string.Empty}@{this.Host ?? string.Empty}:{(Port.HasValue ? Port.Value : 27017)}"; } }
    public string DatabaseName { get; private set; } = default!;
    public string? Host { get; private set; }
    public string? Password { get; private set; }
    public int? Port { get; private set; }
    public string? UserName { get; private set; }
    #endregion Properties
}
