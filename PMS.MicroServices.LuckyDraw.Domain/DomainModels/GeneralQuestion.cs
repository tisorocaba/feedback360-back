using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class GeneralQuestion
    : DomainModelBase<Guid>
{
    #region Properties
    public string Abbreviation { get; set; } = default!;
    public string SelfAssessmentQuestion { get; set; } = default!;
    public string CoWorkerQuestion { get; set; } = default!;
    public string SubordinateQuestion { get; set; } = default!;
    #endregion Properties
}
