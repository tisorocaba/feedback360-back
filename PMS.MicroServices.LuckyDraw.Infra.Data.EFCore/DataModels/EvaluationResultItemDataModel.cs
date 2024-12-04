using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class EvaluationResultItemDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IEvaluationResultItemDataModel
{
    #region Properties
    public Guid IdEvaluationResult { get; set; }
    public Guid? IdQuestion { get; set; }
    public decimal? ResultValue { get; set; }
    public string? ResultText { get; set; }

    [ForeignKey(nameof(IdEvaluationResult))]
    public virtual EvaluationResultDataModel EvaluationResult { get; set; } = default!;

    [ForeignKey(nameof(IdQuestion))]
    public virtual QuestionDataModel? Question { get; set; }
    #endregion Properties
}
