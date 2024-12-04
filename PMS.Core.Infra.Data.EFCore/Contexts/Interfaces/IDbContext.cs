using Microsoft.EntityFrameworkCore;

namespace PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;

public interface IDbContext
    : IDisposable
{
    #region Methods
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    #endregion Methods

    #region Properties

    #endregion Properties
}
