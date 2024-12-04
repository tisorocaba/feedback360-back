using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveEvaluationResultUseCase
    : UseCaseBase,
    ISaveEvaluationResultUseCase
{
    #region Constructors
    public SaveEvaluationResultUseCase(IAddEvaluationResultUseCase addEvaluationResultUseCase, IGetEvaluationResultUseCase getEvaluationResultUseCase,
                                       IUpdateEvaluationResultUseCase updateEvaluationResultUseCase, IUnitOfWork unitOfWork)
    {
        this._addEvaluationResultUseCase = addEvaluationResultUseCase;
        this._getEvaluationResultUseCase = getEvaluationResultUseCase;
        this._updateEvaluationResultUseCase = updateEvaluationResultUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddEvaluationResultUseCase _addEvaluationResultUseCase;
    readonly IGetEvaluationResultUseCase _getEvaluationResultUseCase;
    readonly IUpdateEvaluationResultUseCase _updateEvaluationResultUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<EvaluationResultUseCaseModel?> ExecuteAsync(EvaluationResultUseCaseModel? model, bool commit = false)
    {
        EvaluationResultUseCaseModel? result = null;
        if (model != null)
        {
            if (model.HasEmptyKey)
                result = await this._addEvaluationResultUseCase.ExecuteAsync(model, false);
            else
            {
                var useCaseModel = await this._getEvaluationResultUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    result = await this._updateEvaluationResultUseCase.ExecuteAsync(model, false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
        return result;
    }
    #endregion Methods
}
