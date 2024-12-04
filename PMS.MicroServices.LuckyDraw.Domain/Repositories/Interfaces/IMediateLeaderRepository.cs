using PMS.Core.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

public interface IMediateLeaderRepository
    : IRepository<MediateLeader, Guid>
{
    #region Properties
    List<LeadershipQuestion>? Questions { get; set; }
    #endregion Properties
}
