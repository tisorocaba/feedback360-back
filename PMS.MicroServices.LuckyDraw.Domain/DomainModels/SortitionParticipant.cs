using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class SortitionParticipant
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public Guid IdSortition { get; set; }
    public int Number { get; set; }
    public string Code { get; set; } = default!;
    public int AccessCounter { get; set; }

    public virtual Sortition Sortition { get; set; } = default!;
    #endregion Properties
}
