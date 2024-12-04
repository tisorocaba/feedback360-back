using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class AssessmentResult
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public Guid? IdSortition { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? NickName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Code { get; set; } = default!;
    public bool BelongsToManagementTeam { get; set; }
    public bool HasImmediateSubordinates { get; set; }
    public bool HasMediateSubordinates { get; set; }

    public virtual Sortition? Sortition { get; set; }
    #endregion Properties
}
