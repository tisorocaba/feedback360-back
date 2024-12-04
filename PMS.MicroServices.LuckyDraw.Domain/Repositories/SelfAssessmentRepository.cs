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

public class SelfAssessmentRepository
    : MongoDbRepositoryBase<SelfAssessment, SelfAssessmentMongoDbDataModel, object, Guid>,
    ISelfAssessmentRepository
{
    #region Constructors
    public SelfAssessmentRepository(ISelfAssessmentMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    SelfAssessment? ConvertDraftToOfficial(SelfAssessmentDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<SelfAssessment>> FindAsync(Expression<Func<SelfAssessment, bool>> expression,
                                                               params OrderByExpression<SelfAssessment, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<SelfAssessment, SelfAssessmentMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<SelfAssessment>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.Author))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<SelfAssessmentDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<SelfAssessment?> FindOneAsync(Expression<Func<SelfAssessment, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<SelfAssessment, SelfAssessmentMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<SelfAssessmentDraft>(this.AdapterConfig));
    }

    public override async Task<List<SelfAssessment>> GetAllAsync(params OrderByExpression<SelfAssessment, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<SelfAssessment>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.Author))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<SelfAssessmentDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<SelfAssessment?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<SelfAssessmentDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<GeneralQuestion>? Questions { get; set; }
    #endregion Properties
}
