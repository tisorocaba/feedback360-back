using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class ManagementQuestionDomainService
    : DomainServiceBase<ManagementQuestion, Guid>,
    IManagementQuestionDomainService
{
    #region Constructors
    public ManagementQuestionDomainService(IManagementQuestionRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
