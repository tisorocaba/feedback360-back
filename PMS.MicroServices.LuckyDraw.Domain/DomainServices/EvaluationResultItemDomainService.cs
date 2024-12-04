using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class EvaluationResultItemDomainService
    : DomainServiceBase<EvaluationResultItem, Guid>,
    IEvaluationResultItemDomainService
{
    #region Constructors
    public EvaluationResultItemDomainService(IEvaluationResultItemRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
