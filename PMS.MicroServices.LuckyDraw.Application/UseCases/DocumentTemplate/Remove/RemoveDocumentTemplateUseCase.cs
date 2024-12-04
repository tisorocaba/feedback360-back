using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class RemoveDocumentTemplateUseCase
    : IRemoveDocumentTemplateUseCase
{
    #region Constructors
    public RemoveDocumentTemplateUseCase(IDocumentTemplateDomainService documentTemplateDomainService, IUnitOfWork unitOfWork)
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
    public async Task ExecuteAsync(Guid id, bool commit = false)
    {
        if (!TypeUtility.IsSetByDefault(id))
        {
            var domainModel = await this._documentTemplateDomainService.GetByIdAsync(id).ConfigureAwait(false);

            if (domainModel != null)
                await this._documentTemplateDomainService.RemoveAsync(id).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
    #endregion Methods
}
