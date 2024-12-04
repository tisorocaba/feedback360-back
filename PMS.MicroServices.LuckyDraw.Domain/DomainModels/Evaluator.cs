using PMS.Core.Domain.DomainModels.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class Evaluator
    : AuditableDomainModelBase<Guid>
{
    #region Methods
    public override void OnBeforeAdding()
    {
        base.OnBeforeAdding();

        this.IdImmediateLeader = this.ImmediateLeader?.Id;
        this.IdMediateLeader = this.MediateLeader?.Id;

        this.ImmediateLeader = null;
        this.MediateLeader = null;
    }
    #endregion Methods

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
    public virtual Evaluator? MediateLeader { get; set; }

    [ForeignKey(nameof(IdImmediateLeader))]
    public virtual Evaluator? ImmediateLeader { get; set; }

    public virtual List<EvaluationResult> EvaluationResults { get; set; } = default!;
    #endregion Properties
}
