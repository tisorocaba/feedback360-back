using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class TeamUseCaseModel
    : AuditableUseCaseModelBase<Guid, TeamUseCaseModel>
{
    #region Methods
    public override void Bind(TeamUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public int NumberOfParticipants { get; set; }
    #endregion Properties
}
