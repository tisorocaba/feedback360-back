using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Question
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public string? Abbreviation { get; set; }
    public string? Content { get; set; }
    public string? SelfAssessmentContent { get; set; }
    public string? CoWorkerContent { get; set; }
    public string? SubordinateContent { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }
    public PurposeTypeEnum PurposeType { get; set; }
    #endregion Properties
}
