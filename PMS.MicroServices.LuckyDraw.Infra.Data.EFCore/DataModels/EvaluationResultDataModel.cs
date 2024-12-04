using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class EvaluationResultDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IEvaluationResultDataModel
{
    #region Properties
	public Guid? IdSortition { get; set; }
    public Guid IdEvaluator { get; set; }
    public Guid? IdEvaluatedCoWorker { get; set; }
    public string? EvaluatedCoWorkerName { get; set; }
    public string? EvaluatedCoWorkerType { get; set; }

    [ForeignKey(nameof(IdSortition))]
    public virtual SortitionDataModel? Sortition { get; set; } = default!;

    [ForeignKey(nameof(IdEvaluator))]
    public virtual EvaluatorDataModel Evaluator { get; set; } = default!;

    //[ForeignKey(nameof(IdEvaluatedCoWorker))]
    [NotMapped]
    public virtual EvaluatorDataModel? EvaluatedCoWorker { get; set; } = default!;

    public virtual List<EvaluationResultItemDataModel> EvaluationResultItems { get; set; } = default!;
    #endregion Properties
}
