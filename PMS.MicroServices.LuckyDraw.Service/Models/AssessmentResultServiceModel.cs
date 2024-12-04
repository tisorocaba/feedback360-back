using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public Guid? IdSortition { get; set; } = default!;
    public string? UserName { get; set; } = default!;
    public string? Email { get; set; }
    public string Code { get; set; } = default!;

    public virtual SortitionServiceModel? Sortition { get; set; }
    #endregion Properties
}
