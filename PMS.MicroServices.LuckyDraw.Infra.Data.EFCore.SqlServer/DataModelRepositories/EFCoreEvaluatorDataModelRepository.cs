using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.Core.Infra.Data.EFCore.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories;

public class EFCoreEvaluatorDataModelRepository
    : EFCoreDataModelRepositoryBase<EvaluatorDataModel, Guid>,
    IEFCoreEvaluatorDataModelRepository
{
    #region Constructors
    public EFCoreEvaluatorDataModelRepository(IDbContext context)
        : base(context)
    {

    }
    #endregion Constructors
}
