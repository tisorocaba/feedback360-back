using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class SortitionParticipantPrinting
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public Guid IdSortition { get; set; }

    public virtual Sortition Sortition { get; set; } = default!;
    #endregion Properties
}
