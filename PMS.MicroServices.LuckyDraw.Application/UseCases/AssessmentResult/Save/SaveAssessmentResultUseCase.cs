using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveAssessmentResultUseCase
    : UseCaseBase,
    ISaveAssessmentResultUseCase
{
    #region Constructors
    public SaveAssessmentResultUseCase(IAddAssessmentResultUseCase addAssessmentResultUseCase, IGetAssessmentResultUseCase getAssessmentResultUseCase,
                                       IUpdateAssessmentResultUseCase updateAssessmentResultUseCase, IUnitOfWork unitOfWork)
    {
        this._addAssessmentResultUseCase = addAssessmentResultUseCase;
        this._getAssessmentResultUseCase = getAssessmentResultUseCase;
        this._updateAssessmentResultUseCase = updateAssessmentResultUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddAssessmentResultUseCase _addAssessmentResultUseCase;
    readonly IGetAssessmentResultUseCase _getAssessmentResultUseCase;
    readonly IUpdateAssessmentResultUseCase _updateAssessmentResultUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false)
    {
        if (model != null)
        {
            if (model.HasEmptyKey)
                await this._addAssessmentResultUseCase.ExecuteAsync(model, false);
            else
            {
                var useCaseModel = await this._getAssessmentResultUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    await this._updateAssessmentResultUseCase.ExecuteAsync(model, false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
