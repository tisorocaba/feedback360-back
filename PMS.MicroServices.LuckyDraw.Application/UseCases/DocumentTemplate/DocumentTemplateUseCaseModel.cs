using PMS.Core.Application.Models.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class DocumentTemplateUseCaseModel
    : AuditableUseCaseModelBase<Guid, DocumentTemplateUseCaseModel>
{
    #region Methods
    public override void Bind(DocumentTemplateUseCaseModel source)
    {

    }
    #endregion Methods

    #region Properties
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string Content { get; set; } = default!;
    public string? Keywords { get; set; }
    public string? Version { get; set; }
    #endregion Properties
}
