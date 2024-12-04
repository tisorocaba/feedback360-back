using PMS.Core.Application.Models.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SortitionUseCaseModel
    : AuditableUseCaseModelBase<Guid, SortitionUseCaseModel>
{
    #region Methods
    public override void Bind(SortitionUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public Guid? IdTeam { get; set; }
    public int Number { get; set; }
    public int NumberOfParticipants { get; set; }
    public string Content { get; set; } = default!;

    public TeamUseCaseModel? Team { get; set; } = default!;

    public string? TeamName { get; set; }

    public bool IsValid { get; set; }

    public List<SortitionParticipantPrintingUseCaseModel> Impressions { get; private set; } = default!;
    public List<SortitionParticipantUseCaseModel> Participants { get; private set; } = default!;
    #endregion Properties
}
