using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class DocumentTemplate
    : AuditableDomainModelBase<Guid>
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Content { get; set; } = default!;
    public string? Keywords { get; set; }
    public string? Version { get; set; }
    #endregion Properties
}
