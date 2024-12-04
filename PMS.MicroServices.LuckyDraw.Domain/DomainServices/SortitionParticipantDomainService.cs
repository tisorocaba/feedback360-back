using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SortitionParticipantDomainService
    : DomainServiceBase<SortitionParticipant, Guid>,
    ISortitionParticipantDomainService
{
    #region Constructors
    public SortitionParticipantDomainService(ISortitionParticipantRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
