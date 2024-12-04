using PMS.Core.Infra.CrossCutting.Attributes;

namespace PMS.MicroServices.LuckyDraw.Domain.Enums;

public enum AgreementEnum
{
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_NOT_SET")]
    NotSet = 0,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_TOTALLY_DISAGREE")]
    TotallyDisagree = 1,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_DISAGREE")]
    Disagree = 2,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_PARTIALLY_DISAGREE")]
    PartiallyDisagree = 3,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_NEUTRAL")]
    Neutral = 4,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_PARTIALLY_AGREE")]
    PartiallyAgree = 5,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_AGREE")]
    Agree = 6,
    [LocalizedDescription(typeof(Resources.LuckyDrawDomainResource), "AGREEMENT_ENUM_TOTALLY_AGREE")]
    TotallyAgree = 7
}
