using Microsoft.EntityFrameworkCore;
using PMS.Core.Infra.Data.DataModels.Base;
using PMS.Core.Infra.Data.Repositories.Interfaces;

namespace PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;

public interface IEFCoreDataModelRepository<TDataModel, TKey>
    : IDataModelRepository<TDataModel, TKey>
    where TDataModel : DataModelBase<TKey>
{
    #region Properties
    IDbContext Context { get; }
    DbSet<TDataModel> DbSet { get; }
    #endregion Properties
}
