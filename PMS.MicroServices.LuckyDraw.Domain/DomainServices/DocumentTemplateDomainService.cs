using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class DocumentTemplateDomainService
    : DomainServiceBase<DocumentTemplate, Guid>,
    IDocumentTemplateDomainService
{
    #region Constructors
    public DocumentTemplateDomainService(IDocumentTemplateRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
