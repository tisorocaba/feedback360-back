using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class AuthorDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IAuthorDataModel
{
    #region Properties
    public Guid? IdLeader { get; set; }
    public string Name { get; set; } = default!;
    public string? NickName { get; set; }
    public string? Email { get; set; }
    public string? JobTitle { get; set; }
    public bool HasImmediateSubordinates { get; set; }
    public bool HasMediateSubordinates { get; set; }
    public bool BelongsToManagementTeam { get; set; }
    public string? Placement { get; set; }

    [ForeignKey(nameof(IdLeader))]
    public virtual AuthorDataModel? Leader { get; set; }
    #endregion Properties
}
