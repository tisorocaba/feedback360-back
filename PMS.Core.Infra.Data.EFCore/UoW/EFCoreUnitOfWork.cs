using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;

namespace PMS.Core.Infra.Data.EFCore.UoW;

public class EFCoreUnitOfWork
    : IUnitOfWork,
    IDisposable
{
    #region Constructors
    public EFCoreUnitOfWork(IDbContext context)
    {
        this._context = context;
    }
    #endregion Constructors

    #region Fields
    private readonly IDbContext _context;
    #endregion Fields

    #region Handlers
    public async Task<bool> CommitAsync()
    {
        var result = await this._context.SaveChangesAsync();
        return result > 0;
    }

    public void Dispose()
    {
        this._context.Dispose();
        GC.SuppressFinalize(this);
    }
    #endregion Handlers
}
