using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class EvaluationResultItem
    : AuditableDomainModelBase<Guid>
{
    #region Methods
    public override void OnBeforeAdding()
    {
        base.OnBeforeAdding();

        this.IdEvaluationResult = this.EvaluationResult.Id;
        this.IdQuestion = this.Question?.Id;

        this.EvaluationResult = default!;
        this.Question = default!;
    }
    #endregion Methods

    #region Properties
    public Guid IdEvaluationResult { get; set; }
    public Guid? IdQuestion { get; set; }
    public decimal? ResultValue { get; set; }
    public string? ResultText { get; set; }

    public virtual EvaluationResult EvaluationResult { get; set; } = default!;

    public virtual Question? Question { get; set; }
    #endregion Properties
}
