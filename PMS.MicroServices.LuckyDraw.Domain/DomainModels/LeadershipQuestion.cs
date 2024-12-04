using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class LeadershipQuestion
    : DomainModelBase<Guid>
{
    #region Properties
    public string Abbreviation { get; set; } = default!;
    public string Question { get; set; } = default!;
    #endregion Properties
}
