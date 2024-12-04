using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class TeamDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    ITeamDataModel
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int NumberOfParticipants { get; set; }
    public bool Active { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
