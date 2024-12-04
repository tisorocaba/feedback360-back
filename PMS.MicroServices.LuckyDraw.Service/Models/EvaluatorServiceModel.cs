using PMS.Core.Service.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class EvaluatorServiceModel
    : ServiceModelBase<Guid>
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

    [ForeignKey(nameof(IdMediateLeader))]
    public virtual EvaluatorServiceModel? MediateLeader { get; set; }

    [ForeignKey(nameof(IdImmediateLeader))]
    public virtual EvaluatorServiceModel? ImmediateLeader { get; set; }

    //public virtual List<EvaluationResultServiceModel> EvaluationResults { get; set; } = default!;
    #endregion Properties
}
