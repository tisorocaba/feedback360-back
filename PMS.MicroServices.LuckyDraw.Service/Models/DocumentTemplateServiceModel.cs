using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class DocumentTemplateServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Content { get; set; } = default!;
    public string? Keywords { get; set; }
    public string? Version { get; set; }
    #endregion Properties
}
