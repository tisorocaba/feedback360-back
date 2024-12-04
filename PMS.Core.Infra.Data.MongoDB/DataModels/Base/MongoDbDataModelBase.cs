using MongoDB.Bson.Serialization.Attributes;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.Data.MongoDB.Constants;

namespace PMS.Core.Infra.Data.MongoDB.DataModels.Base;

public abstract class MongoDbDataModelBase
{
    #region Methods
    public void SetId(Guid id)
    {
        if (Id == null)
        {
            var idParts = id.ToString().Split(CoreInfraCrossCuttingConstants.Hyphen);
            if (idParts.Length > 1)
                this.Id = string.Join(string.Empty, idParts.Skip(1).ToArray());
        }
    }
    #endregion Methods

    #region Properties
    [BsonElement(CoreInfraDataMongoDbConstants.IdAttributeName)]
    public object Id { get; set; } = default!;

    [BsonElement(CoreInfraDataMongoDbConstants.CreatedAtAttributeName)]
    public DateTime? CreatedAt { get; set; }

    public IDictionary<string, object>? ExtraElements { get; set; }
    #endregion Properties
}
