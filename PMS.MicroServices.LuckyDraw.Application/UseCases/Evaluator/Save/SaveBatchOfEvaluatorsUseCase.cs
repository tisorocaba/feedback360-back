using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveBatchOfEvaluatorsUseCase
    : UseCaseBase,
    ISaveBatchOfEvaluatorsUseCase
{
    #region Constructors
    public SaveBatchOfEvaluatorsUseCase(IGetAllEvaluatorsUseCase getAllEvaluatorsUseCase, ISaveEvaluatorUseCase saveEvaluatorUseCase, IUnitOfWork unitOfWork)
    {
        this._getAllEvaluatorsUseCase = getAllEvaluatorsUseCase;
        this._saveEvaluatorUseCase = saveEvaluatorUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllEvaluatorsUseCase _getAllEvaluatorsUseCase;
    readonly ISaveEvaluatorUseCase _saveEvaluatorUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Tasks
    public async Task ExecuteAsync(List<EvaluatorUseCaseModel> list, bool commit = false)
    {
        if (list?.Any() ?? false)
        {
            var useCaseModels = await this._getAllEvaluatorsUseCase.ExecuteAsync();
            for (int itemIndex = 0; itemIndex < list.Count; itemIndex++)
            {
                var currentItem = list[itemIndex];
                if (currentItem != null)
                {
                    string? currentEmailItem = currentItem.Email?.ToLower(), currentNickNameItem = currentItem.NickName?.ToLower();
                    string? currentNameItem = currentItem.Name?.ToLower();
                    var foundUseCaseModel = useCaseModels.FirstOrDefault(e => (!string.IsNullOrEmpty(e.Email)) && (e.Email?.ToLower() == currentEmailItem) ||
                                                                              (!string.IsNullOrEmpty(e.NickName)) && (e.NickName?.ToLower() == currentNickNameItem) ||
                                                                              (!string.IsNullOrEmpty(e.Name)) && (e.Name?.ToLower() == currentNameItem));

                    if (foundUseCaseModel == null)
                    {
                        if (currentItem.ImmediateLeader?.HasEmptyKey ?? false)
                            currentItem.ImmediateLeader = list.FirstOrDefault(i => i.Name == currentItem.ImmediateLeader.Name);

                        if (currentItem.MediateLeader?.HasEmptyKey ?? false)
                            currentItem.MediateLeader = list.FirstOrDefault(i => i.Name == currentItem.MediateLeader.Name);

                        currentItem = await this._saveEvaluatorUseCase.ExecuteAsync(currentItem, false);
                        if (currentItem != null)
                            list[itemIndex] = currentItem;
                    }
                }
            }
            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Tasks
}

