using PMS.Core.Application.Models.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class QuestionUseCaseModel
    : AuditableUseCaseModelBase<Guid, QuestionUseCaseModel>
{
    #region Methods
    public override void Bind(QuestionUseCaseModel source)
    {
        
    }
    #endregion Methods

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
