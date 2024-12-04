using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class EvaluatorDomainService
    : DomainServiceBase<Evaluator, Guid>,
    IEvaluatorDomainService
{
    #region Constructors
    public EvaluatorDomainService(IEvaluatorRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
