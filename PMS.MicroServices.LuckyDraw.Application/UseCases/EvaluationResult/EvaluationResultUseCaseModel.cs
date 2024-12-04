using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class EvaluationResultUseCaseModel
    : AuditableUseCaseModelBase<Guid, EvaluationResultUseCaseModel>
{
    #region Methods
    public override void Bind(EvaluationResultUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public Guid? IdSortition { get; set; }
    public Guid IdEvaluator { get; set; }
    public Guid? IdEvaluatedCoWorker { get; set; }
    public string? EvaluatedCoWorkerName { get; set; }
    public string? EvaluatedCoWorkerType { get; set; }

    public SortitionUseCaseModel? Sortition { get; set; } = default!;

    public EvaluatorUseCaseModel Evaluator { get; set; } = default!;

    public virtual EvaluatorUseCaseModel? EvaluatedCoWorker { get; set; } = default!;

    public virtual List<EvaluationResultItemUseCaseModel> EvaluationResultItems { get; set; } = default!;
    #endregion Properties
}
