using MongoDB.Driver;
using PMS.Core.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.Core.Infra.Data.MongoDB.DataModels.Base;
using PMS.Core.Infra.Data.MongoDB.Mappings.Interfaces;
using PMS.Core.Infra.Data.MongoDB.Models;
using System.Collections.Concurrent;

namespace PMS.Core.Infra.Data.MongoDB.DataContexts.Base;

public abstract class MongoDbDataContextBase
    : IMongoDbDataContext
{
    #region Constructors
    protected MongoDbDataContextBase(MongoClient client, MongoDbOptionsLoader loader)
    {
        this.Client = client;
        this.Options = loader.ToOptions();

        this.Database = client.GetDatabase(name: this.Options.DatabaseName, settings: this.Options.MongoDatabaseSettings);

        this.Init();
    }
    #endregion Constructors

    #region Fields
    private static bool _hasInitialized = false;
    private static bool _supportTransaction = true;
    private static ConcurrentDictionary<Type, object> _mongoCollectionDictionary = new();
    #endregion Fields

    #region Methods
    public async Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        if (!_supportTransaction)
            return;

        if (ClientSessionHandle != null)
            throw new InvalidOperationException(Resources.CoreInfraDataMongoDbResource.TRANSACTION_ALREADY_STARTED);

        ClientSessionHandle = await Client.StartSessionAsync(options: Options.MongoDbClientSessionOptions, cancellationToken);

        try { ClientSessionHandle.StartTransaction(); }
        catch
        {
            ClientSessionHandle = null;
            _supportTransaction = false;
        }
    }

    public async Task CloseConnectionAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        if (!_supportTransaction)
            return;

        if (ClientSessionHandle == null)
            throw new InvalidOperationException(Resources.CoreInfraDataMongoDbResource.TRANSACTION_NOT_STARTED);

        await ClientSessionHandle.CommitTransactionAsync(cancellationToken);

        ClientSessionHandle.Dispose();
        ClientSessionHandle = null;
    }

    public IMongoCollection<TMongoDbDataModel> GetCollection<TMongoDbDataModel>()
    {
        _mongoCollectionDictionary.TryGetValue(typeof(TMongoDbDataModel), out object? mongoCollection);
        return mongoCollection is null ?
            throw new InvalidOperationException(Resources.CoreInfraDataMongoDbResource.COLLECTION_NOT_FOUND) :
                (IMongoCollection<TMongoDbDataModel>)mongoCollection;
    }

    public void Init()
    {
        if (_hasInitialized)
            return;

        this.InitInternal();

        _hasInitialized = true;
    }

    public async Task OpenConnectionAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public void RegisterMongoCollection<TMongoDbDataModel>(string name, IMongoDbDataModelMap<TMongoDbDataModel> mongoDbDataModelMap,
                                                           Func<IndexKeysDefinition<TMongoDbDataModel>> indexConfigHandler,
                                                           MongoCollectionSettings? collectionSettings = null)
        where TMongoDbDataModel : MongoDbDataModelBase
    {
        var indexKeysDefinition = indexConfigHandler();

        var mongoCollection = Database.GetCollection<TMongoDbDataModel>(name, collectionSettings);
        if (mongoCollection != null)
        {
            mongoCollection.Indexes.CreateOne(
                model: new CreateIndexModel<TMongoDbDataModel>(indexKeysDefinition, options: new CreateIndexOptions { Sparse = true })
            );

            var currentType = typeof(TMongoDbDataModel);
            if (currentType != null)
            {
                if (!_mongoCollectionDictionary.ContainsKey(currentType))
                    _mongoCollectionDictionary.TryAdd(key: currentType, value: mongoCollection);
            }
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        if (!_supportTransaction)
            return;

        if (ClientSessionHandle == null)
            throw new InvalidOperationException(Resources.CoreInfraDataMongoDbResource.TRANSACTION_NOT_STARTED);

        await ClientSessionHandle.AbortTransactionAsync(cancellationToken);

        ClientSessionHandle.Dispose();
        ClientSessionHandle = null;
    }

    protected abstract void InitInternal();

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
    #endregion Methods

    #region Properties
    public IClientSessionHandle? ClientSessionHandle { get; set; }
    protected MongoClient Client { get; private set; }
    protected IMongoDatabase Database { get; private set; }
    protected MongoDbOptions Options { get; private set; }
    #endregion Properties
}
