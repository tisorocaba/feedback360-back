using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class EvaluationResult
    : AuditableDomainModelBase<Guid>
{
    #region Methods
    public override void OnBeforeAdding()
    {
        base.OnBeforeAdding();

        this.IdEvaluator = this.Evaluator.Id;
        this.IdEvaluatedCoWorker = this.EvaluatedCoWorker?.Id;
        this.EvaluatedCoWorkerName = this.EvaluatedCoWorker?.Name;

        this.IdSortition = this.Sortition?.Id;

        this.Evaluator = default!;
        this.EvaluatedCoWorker = default!;
        this.Sortition = default!;

        for (int currentItemIndex = 0; currentItemIndex < this.EvaluationResultItems.Count; currentItemIndex++)
        {
            var currentItem = this.EvaluationResultItems[currentItemIndex];
            if (currentItem != null)
                currentItem.PrepareForAddingOrUpdate();
        }
    }
    #endregion Methods

    #region Properties
    public Guid? IdSortition { get; set; }
    public Guid IdEvaluator { get; set; }
    public Guid? IdEvaluatedCoWorker { get; set; }
    public string? EvaluatedCoWorkerName { get; set; }
    public string? EvaluatedCoWorkerType { get; set; }

    public Sortition? Sortition { get; set; } = default!;

    public Evaluator Evaluator { get; set; } = default!;

    public virtual Evaluator? EvaluatedCoWorker { get; set; } = default!;

    public virtual List<EvaluationResultItem> EvaluationResultItems { get; set; } = default!;
    #endregion Properties
}
