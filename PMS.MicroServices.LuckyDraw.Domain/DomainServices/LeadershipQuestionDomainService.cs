using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class LeadershipQuestionDomainService
    : DomainServiceBase<LeadershipQuestion, Guid>,
    ILeadershipQuestionDomainService
{
    #region Constructors
    public LeadershipQuestionDomainService(ILeadershipQuestionRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
