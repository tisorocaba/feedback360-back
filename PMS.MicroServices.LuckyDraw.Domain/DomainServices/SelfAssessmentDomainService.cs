using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SelfAssessmentDomainService
    : DomainServiceBase<SelfAssessment, Guid>,
    ISelfAssessmentDomainService
{
    #region Constructors
    public SelfAssessmentDomainService(ISelfAssessmentRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetGeneralQuestions(List<GeneralQuestion> questions)
    {
        ((ISelfAssessmentRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
