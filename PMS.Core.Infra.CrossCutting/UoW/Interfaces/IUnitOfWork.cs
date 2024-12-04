namespace PMS.Core.Infra.CrossCutting.UoW.Interfaces;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
