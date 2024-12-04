using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class SortitionDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    ISortitionDataModel
{
    #region Properties
    public Guid? IdTeam { get; set; }
    public int Number { get; set; }
    public int NumberOfParticipants { get; set; }
    public string Content { get; set; } = default!;
    public bool Active { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }

    [ForeignKey(nameof(IdTeam))]
    public virtual TeamDataModel? Team { get; set; }

    public virtual List<AssessmentResultDataModel> AssessmentResults { get; set; } = default!;
    public virtual List<EvaluationResultDataModel> EvaluationResults { get; set; } = default!;
    public virtual List<SortitionParticipantDataModel> Participants { get; set; } = default!;
    public virtual List<SortitionParticipantPrintingDataModel> Impressions { get; set; } = default!;
    #endregion Properties
}
