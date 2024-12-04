using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface IManagementTeamDomainService
    : IDomainService<ManagementTeam, Guid>
{
    #region Methods
    public void SetManagementQuestions(List<ManagementQuestion> questions);
    #endregion Methods
}
