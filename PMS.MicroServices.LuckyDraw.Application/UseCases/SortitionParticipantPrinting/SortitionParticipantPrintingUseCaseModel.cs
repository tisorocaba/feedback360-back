using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SortitionParticipantPrintingUseCaseModel
    : AuditableUseCaseModelBase<Guid, SortitionParticipantPrintingUseCaseModel>
{
    #region Methods
    public override void Bind(SortitionParticipantPrintingUseCaseModel source)
    {
        
    }
    #endregion Methods

    #region Properties
    public Guid IdSortition { get; set; }

    public virtual SortitionUseCaseModel Sortition { get; set; } = default!;
    #endregion Properties
}
