using PMS.MicroServices.LuckyDraw.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.Enums;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Subordinate
    : EvaluatableDomainModelBase<AgreementAndSatisfactionEnum>
{
    #region Properties
    public string LeadershipAuthor { get; set; } = default!;
    public bool HasSubordinates { get; set; }
    public string? SubordinateName { get; set; }
    public string? SubordinateTeam { get; set; }
    #endregion Properties
}
