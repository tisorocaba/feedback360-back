using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOneDocumentTemplateUseCase
    : UseCaseBase,
    IFindOneDocumentTemplateUseCase
{
    #region Constructors
    public FindOneDocumentTemplateUseCase(IDocumentTemplateDomainService documentTemplateDomainService)
    {
        this._documentTemplateDomainService = documentTemplateDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IDocumentTemplateDomainService _documentTemplateDomainService;
    #endregion Fields

    #region Methods
    public async Task<DocumentTemplateUseCaseModel?> ExecuteAsync(Expression<Func<DocumentTemplateUseCaseModel, bool>> expression)
    {
        var domainModel = await this._documentTemplateDomainService.FindOneAsync(expression.ConvertTo<DocumentTemplateUseCaseModel, DocumentTemplate, bool>())
                                                                   .ConfigureAwait(false);
        return domainModel?.Adapt<DocumentTemplateUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
