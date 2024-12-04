using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.Core.Infra.Data.EFCore.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories;

public class EFCoreSortitionParticipantDataModelRepository
    : EFCoreDataModelRepositoryBase<SortitionParticipantDataModel, Guid>,
    IEFCoreSortitionParticipantDataModelRepository
{
    #region Constructors
    public EFCoreSortitionParticipantDataModelRepository(IDbContext context)
        : base(context)
    {
        this.DbSet.Include(i => i.Sortition);
    }
    #endregion Constructors
}
