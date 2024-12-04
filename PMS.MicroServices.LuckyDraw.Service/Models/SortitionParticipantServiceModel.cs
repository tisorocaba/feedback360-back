using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class SortitionParticipantServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public Guid IdSortition { get; set; }
    public int Number { get; set; }
    public string Code { get; set; } = default!;
    public int AccessCounter { get; set; }

    public virtual SortitionServiceModel Sortition { get; set; } = default!;
    #endregion Properties
}
