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

public class ImmediateLeaderRepository
    : MongoDbRepositoryBase<ImmediateLeader, ImmediateLeaderMongoDbDataModel, object, Guid>,
    IImmediateLeaderRepository
{
    #region Constructors
    public ImmediateLeaderRepository(IImmediateLeaderMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    ImmediateLeader? ConvertDraftToOfficial(ImmediateLeaderDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<ImmediateLeader>> FindAsync(Expression<Func<ImmediateLeader, bool>> expression, params OrderByExpression<ImmediateLeader, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<ImmediateLeader, ImmediateLeaderMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<ImmediateLeader>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<ImmediateLeaderDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<ImmediateLeader?> FindOneAsync(Expression<Func<ImmediateLeader, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<ImmediateLeader, ImmediateLeaderMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<ImmediateLeaderDraft>(this.AdapterConfig));
    }

    public override async Task<List<ImmediateLeader>> GetAllAsync(params OrderByExpression<ImmediateLeader, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<ImmediateLeader>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<ImmediateLeaderDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<ImmediateLeader?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<ImmediateLeaderDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<LeadershipQuestion>? Questions { get; set; }
    #endregion Properties
}
