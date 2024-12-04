using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.Core.Infra.Data.EFCore.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories;

public class EFCoreEvaluationResultDataModelRepository
    : EFCoreDataModelRepositoryBase<EvaluationResultDataModel, Guid>,
    IEFCoreEvaluationResultDataModelRepository
{
    #region Constructors
    public EFCoreEvaluationResultDataModelRepository(IDbContext context)
        : base(context)
    {
        this.DbSet.Include(i => i.Evaluator);
        this.DbSet.Include(i => i.EvaluatedCoWorker);
        this.DbSet.Include(i => i.EvaluationResultItems);
        this.DbSet.Include(i => i.Sortition);
    }
    #endregion Constructors
}
