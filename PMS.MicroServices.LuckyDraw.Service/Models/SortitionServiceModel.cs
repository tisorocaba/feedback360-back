using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class SortitionServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public Guid? IdTeam { get; set; }
    public int Number { get; set; }
    public int NumberOfParticipants { get; set; }
    public string Content { get; set; } = default!;

    public TeamServiceModel? Team { get; set; } = default!;

    public string? TeamName { get; set; }

    public List<SortitionParticipantServiceModel> Participants { get; private set; } = default!;
    #endregion Properties
}
