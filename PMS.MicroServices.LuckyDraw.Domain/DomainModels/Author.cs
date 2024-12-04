using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Author
    : DomainModelBase<Guid>
{
    #region properties
    public string? Name { get; set; }
    public string? Email { get; set; }
    public bool HasImmediateSubordinates { get; set; } = default!;
    public bool HasMediateSubordinates { get; set; } = default!;
    public string? JobTitle { get; set; }
    public bool BelongsToManagementTeam { get; set; }
    public string? NickName { get; set; }
    public string? Placement { get; set; }
    #endregion Properties
}
