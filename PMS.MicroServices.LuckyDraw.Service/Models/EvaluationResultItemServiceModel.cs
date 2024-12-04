using PMS.Core.Service.Base;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class EvaluationResultItemServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public Guid IdEvaluationResult { get; set; }
    public Guid? IdQuestion { get; set; }
    public decimal? ResultValue { get; set; }
    public string? ResultText { get; set; }

    public virtual EvaluationResultUseCaseModel EvaluationResult { get; set; } = default!;

    public virtual QuestionUseCaseModel? Question { get; set; }
    #endregion Properties
}
