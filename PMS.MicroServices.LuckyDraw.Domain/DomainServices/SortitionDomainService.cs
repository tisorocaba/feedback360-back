using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SortitionDomainService
    : DomainServiceBase<Sortition, Guid>,
    ISortitionDomainService
{
    #region Constructors
    public SortitionDomainService(ISortitionRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
