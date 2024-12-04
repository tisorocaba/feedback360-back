using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class ImmediateLeaderDomainService
    : DomainServiceBase<ImmediateLeader, Guid>,
    IImmediateLeaderDomainService
{
    #region Constructors
    public ImmediateLeaderDomainService(IImmediateLeaderRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetLeadershipQuestions(List<LeadershipQuestion> questions)
    {
        ((IImmediateLeaderRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
