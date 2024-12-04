using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class CoWorkerDomainService
    : DomainServiceBase<CoWorker, Guid>,
    ICoWorkerDomainService
{
    #region Constructors
    public CoWorkerDomainService(ICoWorkerRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetGeneralQuestions(List<GeneralQuestion> questions)
    {
        ((ICoWorkerRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
