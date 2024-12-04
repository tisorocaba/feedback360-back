using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Team
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int NumberOfParticipants { get; set; }
    #endregion Properties
}
