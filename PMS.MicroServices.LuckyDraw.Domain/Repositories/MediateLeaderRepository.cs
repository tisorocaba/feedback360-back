using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class MediateLeaderRepository
    : MongoDbRepositoryBase<MediateLeader, MediateLeaderMongoDbDataModel, object, Guid>,
    IMediateLeaderRepository
{
    #region Constructors
    public MediateLeaderRepository(IMediateLeaderMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    MediateLeader? ConvertDraftToOfficial(MediateLeaderDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<MediateLeader>> FindAsync(Expression<Func<MediateLeader, bool>> expression, params OrderByExpression<MediateLeader, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<MediateLeader, MediateLeaderMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<MediateLeader>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<MediateLeaderDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<MediateLeader?> FindOneAsync(Expression<Func<MediateLeader, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<MediateLeader, MediateLeaderMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<MediateLeaderDraft>(this.AdapterConfig));
    }

    public override async Task<List<MediateLeader>> GetAllAsync(params OrderByExpression<MediateLeader, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<MediateLeader>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<MediateLeaderDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<MediateLeader?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<MediateLeaderDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<LeadershipQuestion>? Questions { get; set; }
    #endregion Properties
}
