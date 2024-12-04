using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.Core.Infra.Data.EFCore.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories;

public class EFCoreSortitionDataModelRepository
    : EFCoreDataModelRepositoryBase<SortitionDataModel, Guid>,
    IEFCoreSortitionDataModelRepository
{
    #region Constructors
    public EFCoreSortitionDataModelRepository(IDbContext context)
        : base(context)
    {
        this.DbSet.Include(i => i.AssessmentResults);
        this.DbSet.Include(i => i.EvaluationResults);
        this.DbSet.Include(i => i.Impressions);
        this.DbSet.Include(i => i.Participants);
    }
    #endregion Constructors
}
