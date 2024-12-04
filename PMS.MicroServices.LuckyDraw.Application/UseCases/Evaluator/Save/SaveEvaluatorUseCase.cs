using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveEvaluatorUseCase
    : UseCaseBase,
    ISaveEvaluatorUseCase
{
    #region Constructors
    public SaveEvaluatorUseCase(IAddEvaluatorUseCase addEvaluatorUseCase, IGetEvaluatorUseCase getEvaluatorUseCase, IUpdateEvaluatorUseCase updateEvaluatorUseCase, IUnitOfWork unitOfWork)
    {
        this._addEvaluatorUseCase = addEvaluatorUseCase;
        this._getEvaluatorUseCase = getEvaluatorUseCase;
        this._updateEvaluatorUseCase = updateEvaluatorUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddEvaluatorUseCase _addEvaluatorUseCase;
    readonly IGetEvaluatorUseCase _getEvaluatorUseCase;
    readonly IUpdateEvaluatorUseCase _updateEvaluatorUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<EvaluatorUseCaseModel?> ExecuteAsync(EvaluatorUseCaseModel? model, bool commit = false)
    {
        EvaluatorUseCaseModel? result = null;
        if (model != null)
        {
            if (model.HasEmptyKey)
                result = await this._addEvaluatorUseCase.ExecuteAsync(model, false);
            else
            {
                var useCaseModel = await this._getEvaluatorUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    result = await this._updateEvaluatorUseCase.ExecuteAsync(model, false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
        return result;
    }
    #endregion Methods
}
