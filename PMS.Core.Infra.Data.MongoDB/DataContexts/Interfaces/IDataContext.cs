namespace PMS.Core.Infra.Data.MongoDB.DataContexts.Interfaces;

public interface IDataContext
    : IDisposable
{
    Task CloseConnectionAsync(CancellationToken cancellationToken);
    Task OpenConnectionAsync(CancellationToken cancellationToken);

    Task BeginTransactionAsync(CancellationToken cancellationToken);
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}
