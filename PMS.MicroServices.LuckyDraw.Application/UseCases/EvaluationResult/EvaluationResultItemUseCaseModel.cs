using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class EvaluationResultItemUseCaseModel
    : AuditableUseCaseModelBase<Guid, EvaluationResultItemUseCaseModel>
{
    #region Methods
    public override void Bind(EvaluationResultItemUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public Guid IdEvaluationResult { get; set; }
    public Guid? IdQuestion { get; set; }
    public decimal? ResultValue { get; set; }
    public string? ResultText { get; set; }

    public virtual EvaluationResultUseCaseModel EvaluationResult { get; set; } = default!;

    public virtual QuestionUseCaseModel? Question { get; set; }
    #endregion Properties
}
