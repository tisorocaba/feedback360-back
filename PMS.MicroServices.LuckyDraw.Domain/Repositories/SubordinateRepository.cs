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

public class SubordinateRepository
    : MongoDbRepositoryBase<Subordinate, SubordinateMongoDbDataModel, object, Guid>,
    ISubordinateRepository
{
    #region Constructors
    public SubordinateRepository(ISubordinateMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    Subordinate? ConvertDraftToOfficial(SubordinateDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<Subordinate>> FindAsync(Expression<Func<Subordinate, bool>> expression,
                                                            params OrderByExpression<Subordinate, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<Subordinate, SubordinateMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<Subordinate>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.LeadershipAuthor))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<SubordinateDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<Subordinate?> FindOneAsync(Expression<Func<Subordinate, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<Subordinate, SubordinateMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<SubordinateDraft>(this.AdapterConfig));
    }

    public override async Task<List<Subordinate>> GetAllAsync(params OrderByExpression<Subordinate, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<Subordinate>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.LeadershipAuthor))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<SubordinateDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<Subordinate?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<SubordinateDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<GeneralQuestion>? Questions { get; set; }
    #endregion Properties
}
