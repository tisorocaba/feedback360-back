using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class AssessmentResultDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IAssessmentResultDataModel
{
    #region Properties
    public Guid? IdSortition { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? NickName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Code { get; set; } = default!;
    public bool BelongsToManagementTeam { get; set; }
    public bool HasImmediateSubordinates { get; set; }
    public bool HasMediateSubordinates { get; set; }

    public bool Active { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }

    [ForeignKey(nameof(IdSortition))]
    public virtual SortitionDataModel? Sortition { get; set; }
    #endregion Properties
}
