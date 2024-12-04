using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class TeamServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int NumberOfParticipants { get; set; }
    #endregion Properties
}
