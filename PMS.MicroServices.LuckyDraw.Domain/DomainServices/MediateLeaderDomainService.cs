using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class MediateLeaderDomainService
    : DomainServiceBase<MediateLeader, Guid>,
    IMediateLeaderDomainService
{
    #region Constructors
    public MediateLeaderDomainService(IMediateLeaderRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetLeadershipQuestions(List<LeadershipQuestion> questions)
    {
        ((IMediateLeaderRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
