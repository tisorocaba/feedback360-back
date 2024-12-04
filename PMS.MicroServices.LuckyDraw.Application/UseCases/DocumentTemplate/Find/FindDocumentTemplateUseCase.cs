using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindDocumentTemplateUseCase
    : UseCaseBase,
    IFindDocumentTemplateUseCase
{
    #region Constructors
    public FindDocumentTemplateUseCase(IDocumentTemplateDomainService documentTemplateDomainService)
    {
        this._documentTemplateDomainService = documentTemplateDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IDocumentTemplateDomainService _documentTemplateDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<DocumentTemplateUseCaseModel>> ExecuteAsync(Expression<Func<DocumentTemplateUseCaseModel, bool>> expression)
    {
        OrderByExpression<DocumentTemplateUseCaseModel, object> orderByCreatedAt = DocumentTemplateUseCaseExpressions.CreatedAtOrderByAscending;
        var domainModels = await this._documentTemplateDomainService.FindAsync(expression.ConvertTo<DocumentTemplateUseCaseModel, DocumentTemplate, bool>(),
                                                                               orderByCreatedAt.ConvertTo<DocumentTemplateUseCaseModel, DocumentTemplate, object>())
                                                                    .ConfigureAwait(false);
        var useCaseModels = new List<DocumentTemplateUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<DocumentTemplateUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
