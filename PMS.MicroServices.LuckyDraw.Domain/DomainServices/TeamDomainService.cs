using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class TeamDomainService
    : DomainServiceBase<Team, Guid>,
    ITeamDomainService
{
    #region Constructors
    public TeamDomainService(ITeamRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
