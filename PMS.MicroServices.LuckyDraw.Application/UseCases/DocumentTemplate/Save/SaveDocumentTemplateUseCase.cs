using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveDocumentTemplateUseCase
    : UseCaseBase,
    ISaveDocumentTemplateUseCase
{
    #region Constructors
    public SaveDocumentTemplateUseCase(IAddDocumentTemplateUseCase addDocumentTemplateUseCase, IGetDocumentTemplateUseCase getDocumentTemplateUseCase, IUpdateDocumentTemplateUseCase updateDocumentTemplateUseCase, IUnitOfWork unitOfWork)
    {
        this._addDocumentTemplateUseCase = addDocumentTemplateUseCase;
        this._getDocumentTemplateUseCase = getDocumentTemplateUseCase;
        this._updateDocumentTemplateUseCase = updateDocumentTemplateUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddDocumentTemplateUseCase _addDocumentTemplateUseCase;
    readonly IGetDocumentTemplateUseCase _getDocumentTemplateUseCase;
    readonly IUpdateDocumentTemplateUseCase _updateDocumentTemplateUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(DocumentTemplateUseCaseModel? model, bool commit = false)
    {
        if (model != null)
        {
            if (model.HasEmptyKey)
                await this._addDocumentTemplateUseCase.ExecuteAsync(model, false).ConfigureAwait(false);
            else
            {
                var useCaseModel = await this._getDocumentTemplateUseCase.ExecuteAsync(model.Id).ConfigureAwait(false);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    await this._updateDocumentTemplateUseCase.ExecuteAsync(model, false).ConfigureAwait(false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
    #endregion Methods
}
