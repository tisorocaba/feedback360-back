using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateDocumentTemplateUseCase
    : UseCaseBase,
    IUpdateDocumentTemplateUseCase
{
    #region Constructors
    public UpdateDocumentTemplateUseCase(IDocumentTemplateDomainService documentTemplateDomainService, IUnitOfWork unitOfWork)
    {
        this._documentTemplateDomainService = documentTemplateDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IDocumentTemplateDomainService _documentTemplateDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(DocumentTemplateUseCaseModel? model, bool commit = false)
    {
        if ((model != null) && (!model.HasEmptyKey))
        {
            var domainModel = model.Adapt<DocumentTemplate>(this.AdapterConfig);

            await this._documentTemplateDomainService.SaveAsync(domainModel).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
    #endregion Methods
}
