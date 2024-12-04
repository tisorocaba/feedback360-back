using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class SortitionParticipantPrintingDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    ISortitionParticipantPrintingDataModel
{
    #region Properties
    public Guid IdSortition { get; set; }

    [ForeignKey(nameof(IdSortition))]
    public virtual SortitionDataModel Sortition { get; set; } = default!;
    #endregion Properties
}
