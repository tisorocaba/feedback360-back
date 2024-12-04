using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveBatchOfEvaluationResultsUseCase
    : UseCaseBase,
    ISaveBatchOfEvaluationResultsUseCase
{
    #region Constructors
    public SaveBatchOfEvaluationResultsUseCase(ISaveEvaluationResultUseCase saveEvaluationResultUseCase, IUnitOfWork unitOfWork)
    {
        this._saveEvaluationResultUseCase = saveEvaluationResultUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly ISaveEvaluationResultUseCase _saveEvaluationResultUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Tasks
    public async Task ExecuteAsync(List<EvaluationResultUseCaseModel> list, bool commit = false)
    {
        if (list?.Any() ?? false)
        {
            for (int itemIndex = 0; itemIndex < list.Count; itemIndex++)
            {
                var currentItem = list[itemIndex];
                if (currentItem != null)
                    await this._saveEvaluationResultUseCase.ExecuteAsync(currentItem, false);
            }
            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Tasks
}
