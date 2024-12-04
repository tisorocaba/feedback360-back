using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class GeneralQuestionDomainService
    : DomainServiceBase<GeneralQuestion, Guid>,
    IGeneralQuestionDomainService
{
    #region Constructors
    public GeneralQuestionDomainService(IGeneralQuestionRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
