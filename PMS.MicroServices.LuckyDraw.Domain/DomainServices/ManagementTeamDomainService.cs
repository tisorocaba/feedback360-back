using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class ManagementTeamDomainService
    : DomainServiceBase<ManagementTeam, Guid>,
    IManagementTeamDomainService
{
    #region Constructors
    public ManagementTeamDomainService(IManagementTeamRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetManagementQuestions(List<ManagementQuestion> questions)
    {
        ((IManagementTeamRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
