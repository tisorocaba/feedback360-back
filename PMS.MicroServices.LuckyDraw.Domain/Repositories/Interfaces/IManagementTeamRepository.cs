using PMS.Core.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

public interface IManagementTeamRepository
    : IRepository<ManagementTeam, Guid>
{
    #region Properties
    List<ManagementQuestion>? Questions { get; set; }
    #endregion Properties
}
