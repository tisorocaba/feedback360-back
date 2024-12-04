using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class EvaluatorDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IEvaluatorDataModel
{
    #region Properties
	public Guid? IdMediateLeader { get; set; }
    public Guid? IdImmediateLeader { get; set; }
    public string? Name { get; set; }
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public string? JobTitle { get; set; }
    public bool HasImmediateSubordinates { get; set; }
    public bool HasMediateSubordinates { get; set; }
    public bool BelongsToManagementTeam { get; set; }
    public string? Placement { get; set; }
    public bool Active { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }

    [ForeignKey(nameof(IdMediateLeader))]
    public virtual EvaluatorDataModel? MediateLeader { get; set; }

    [ForeignKey(nameof(IdImmediateLeader))]
    public virtual EvaluatorDataModel? ImmediateLeader { get; set; }

    public virtual List<EvaluationResultDataModel> EvaluationResults { get; set; } = default!;
    #endregion Properties
}
