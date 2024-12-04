using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class EvaluationResultServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public Guid? IdSortition { get; set; }
    public Guid IdEvaluator { get; set; }
    public Guid? IdEvaluatedCoWorker { get; set; }
    public string? EvaluatedCoWorkerName { get; set; }
    public string? EvaluatedCoWorkerType { get; set; }

    public SortitionServiceModel? Sortition { get; set; } = default!;

    public EvaluatorServiceModel Evaluator { get; set; } = default!;

    public virtual EvaluatorServiceModel? EvaluatedCoWorker { get; set; } = default!;

    public virtual List<EvaluationResultItemServiceModel> EvaluationResultItems { get; set; } = default!;
    #endregion Properties
}
