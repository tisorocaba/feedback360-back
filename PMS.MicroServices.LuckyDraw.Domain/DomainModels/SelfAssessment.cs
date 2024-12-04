using PMS.MicroServices.LuckyDraw.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.Enums;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class SelfAssessment
    : EvaluatableDomainModelBase<AgreementAndSatisfactionEnum>
{
    #region Properties
    public string? Author { get; set; }
    #endregion Properties
}
