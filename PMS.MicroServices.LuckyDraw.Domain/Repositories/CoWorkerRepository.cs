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

public class CoWorkerRepository
    : MongoDbRepositoryBase<CoWorker, CoWorkerMongoDbDataModel, object, Guid>,
    ICoWorkerRepository
{
    #region Constructors
    public CoWorkerRepository(ICoWorkerMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    CoWorker? ConvertDraftToOfficial(CoWorkerDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<CoWorker>> FindAsync(Expression<Func<CoWorker, bool>> expression, params OrderByExpression<CoWorker, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<CoWorker, CoWorkerMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<CoWorker>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<CoWorkerDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<CoWorker?> FindOneAsync(Expression<Func<CoWorker, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<CoWorker, CoWorkerMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<CoWorkerDraft>(this.AdapterConfig));
    }

    public override async Task<List<CoWorker>> GetAllAsync(params OrderByExpression<CoWorker, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<CoWorker>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            var converted = this.ConvertDraftToOfficial(e.Adapt<CoWorkerDraft>(this.AdapterConfig));
            if (converted != null)
                domainModels.Add(converted);
        });
        return domainModels;
    }

    public override async Task<CoWorker?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<CoWorkerDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<GeneralQuestion>? Questions { get; set; }
    #endregion Properties
}
