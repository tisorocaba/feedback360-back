using PMS.Core.Application.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class EvaluatorUseCaseModel
    : AuditableUseCaseModelBase<Guid, EvaluatorUseCaseModel>
{
    #region Methods
    public override void Bind(EvaluatorUseCaseModel source)
    {
        
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
    public virtual EvaluatorUseCaseModel? MediateLeader { get; set; }

    [ForeignKey(nameof(IdImmediateLeader))]
    public virtual EvaluatorUseCaseModel? ImmediateLeader { get; set; }

    //public virtual List<EvaluationResultUseCaseModel> EvaluationResults { get; set; } = default!;
    #endregion Properties
}
