using PMS.Core.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

public interface ICoWorkerRepository
    : IRepository<CoWorker, Guid>
{
    #region Properties
    List<GeneralQuestion>? Questions { get; set; }
    #endregion Properties
}
