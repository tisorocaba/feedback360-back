using MongoDB.Driver;

namespace PMS.Core.Infra.Data.MongoDB.Models;

public class MongoDbOptions
{
    #region Constructors
    public MongoDbOptions(string connectionString, string databaseName, MongoDatabaseSettings? mongoDatabaseSettings,
                          ClientSessionOptions? mongoDbClientSessionOptions)
    {
        this.ConnectionString = connectionString;
        this.DatabaseName = databaseName;
        this.MongoDatabaseSettings = mongoDatabaseSettings;
        this.MongoDbClientSessionOptions = mongoDbClientSessionOptions;
    }
    #endregion Constructors

    #region Properties
    public string ConnectionString { get; private set; }
    public string DatabaseName { get; private set; }
    public MongoDatabaseSettings? MongoDatabaseSettings { get; private set; }
    public ClientSessionOptions? MongoDbClientSessionOptions { get; private set; }
    #endregion Properties
}
