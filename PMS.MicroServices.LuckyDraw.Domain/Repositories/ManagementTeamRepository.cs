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

public class ManagementTeamRepository
    : MongoDbRepositoryBase<ManagementTeam, ManagementTeamMongoDbDataModel, object, Guid>,
    IManagementTeamRepository
{
    #region Constructors
    public ManagementTeamRepository(IManagementTeamMongoDbDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Methods
    ManagementTeam? ConvertDraftToOfficial(ManagementTeamDraft? draft)
    {
        return draft?.ToOfficial(this.Questions);
    }

    public override async Task<List<ManagementTeam>> FindAsync(Expression<Func<ManagementTeam, bool>> expression,
                                                               params OrderByExpression<ManagementTeam, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.FindAsync(expression.ConvertTo<ManagementTeam, ManagementTeamMongoDbDataModel, bool>(), new CancellationToken());
        var domainModels = new List<ManagementTeam>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.Author))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<ManagementTeamDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<ManagementTeam?> FindOneAsync(Expression<Func<ManagementTeam, bool>> expression)
    {
        var dataModel = await this.DataModelRepository.FindOneAsync(expression.ConvertTo<ManagementTeam, ManagementTeamMongoDbDataModel, bool>(), new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<ManagementTeamDraft>(this.AdapterConfig));
    }

    public override async Task<List<ManagementTeam>> GetAllAsync(params OrderByExpression<ManagementTeam, object?>[] orderByExpressions)
    {
        var dataModels = await this.DataModelRepository.GetAllAsync(ConvertOrderByExpressions(orderByExpressions));
        var domainModels = new List<ManagementTeam>(dataModels.Count());
        dataModels.ToList().ForEach(e =>
        {
            if (!string.IsNullOrWhiteSpace(e.Author))
            {
                var converted = this.ConvertDraftToOfficial(e.Adapt<ManagementTeamDraft>(this.AdapterConfig));
                if (converted != null)
                    domainModels.Add(converted);
            }
        });
        return domainModels;
    }

    public override async Task<ManagementTeam?> GetByIdAsync(Guid id)
    {
        var dataModel = await this.DataModelRepository.GetByIdAsync(id, new CancellationToken());
        return this.ConvertDraftToOfficial(dataModel?.Adapt<ManagementTeamDraft>(this.AdapterConfig));
    }
    #endregion Methods

    #region Properties
    public List<ManagementQuestion>? Questions { get; set; }
    #endregion Properties
}
