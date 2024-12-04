using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class QuestionDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IQuestionDataModel
{
    #region Properties
    public string? Abbreviation { get; set; }
    public string? Content { get; set; }
    public string? SelfAssessmentContent { get; set; }
    public string? CoWorkerContent { get; set; }
    public string? SubordinateContent { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }
    public PurposeTypeEnum PurposeType { get; set; }
    public bool Active { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }

    public virtual List<EvaluationResultItemDataModel> EvaluationResultItems { get; set; } = default!;
    #endregion Properties
}
