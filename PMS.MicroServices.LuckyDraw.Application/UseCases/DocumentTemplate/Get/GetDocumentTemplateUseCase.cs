using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetDocumentTemplateUseCase
    : UseCaseBase,
    IGetDocumentTemplateUseCase
{
    #region Constructors
    public GetDocumentTemplateUseCase(IDocumentTemplateDomainService documentTemplateDomainService)
    {
        this._documentTemplateDomainService = documentTemplateDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IDocumentTemplateDomainService _documentTemplateDomainService;
    #endregion Fields

    #region Methods
    public async Task<DocumentTemplateUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._documentTemplateDomainService.GetByIdAsync(id).ConfigureAwait(false);
        return domainModel?.Adapt<DocumentTemplateUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
