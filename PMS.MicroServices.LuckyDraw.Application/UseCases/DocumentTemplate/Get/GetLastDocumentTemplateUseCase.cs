using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetLastDocumentTemplateUseCase
    : UseCaseBase,
    IGetLastDocumentTemplateUseCase
{
    #region Constructors
    public GetLastDocumentTemplateUseCase(IDocumentTemplateDomainService legalPaperDomainService)
    {
        this._legalPaperDomainService = legalPaperDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IDocumentTemplateDomainService _legalPaperDomainService;
    #endregion Fields

    #region Methods
    public async Task<DocumentTemplateUseCaseModel?> ExecuteAsync()
    {
        var createAtOrderByDescendingExpression = DocumentTemplateUseCaseExpressions.CreatedAtOrderByAscending.ConvertTo<DocumentTemplateUseCaseModel, DocumentTemplate, object>();
        var domainModels = await this._legalPaperDomainService.GetAllAsync(createAtOrderByDescendingExpression).ConfigureAwait(false);
        return domainModels?.FirstOrDefault()?.Adapt<DocumentTemplateUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
