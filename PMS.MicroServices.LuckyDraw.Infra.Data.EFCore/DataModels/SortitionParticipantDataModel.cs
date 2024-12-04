using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class SortitionParticipantDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    ISortitionParticipantDataModel
{
    #region Properties
    public Guid IdSortition { get; set; }
    public int Number { get; set; }
    public string Code { get; set; } = default!;
    public int AccessCounter { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }

    [ForeignKey(nameof(IdSortition))]
    public virtual SortitionDataModel Sortition { get; set; } = default!;
    #endregion Properties
}
