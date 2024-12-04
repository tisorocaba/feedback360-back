using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface IMediateLeaderDomainService
    : IDomainService<MediateLeader, Guid>
{
    #region Methods
    public void SetLeadershipQuestions(List<LeadershipQuestion> questions);
    #endregion Methods
}
