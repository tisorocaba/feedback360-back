using PMS.Core.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

public class DocumentTemplateDataModel
    : EFCoreKeyAuditableDataModelBase<Guid>,
    IDocumentTemplateDataModel
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Content { get; set; } = default!;
    public string? Keywords { get; set; }
    public string? Version { get; set; }

    public Guid? LastUpdateBy { get; set; }
    public DateTime? LastUpdateAt { get; set; }
    #endregion Properties
}
