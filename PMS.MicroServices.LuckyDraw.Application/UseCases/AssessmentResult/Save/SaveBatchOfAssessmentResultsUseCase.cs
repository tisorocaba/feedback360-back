using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveBatchOfAssessmentResultsUseCase
    : UseCaseBase,
    ISaveBatchOfAssessmentResultsUseCase
{
    #region Constructors
    public SaveBatchOfAssessmentResultsUseCase(IGetAllAssessmentResultsUseCase getAllAssessmentResultsUseCase,
                                               ISaveAssessmentResultUseCase saveAssessmentResultUseCase, IUnitOfWork unitOfWork)
    {
        this._getAllAssessmentResultsUseCase = getAllAssessmentResultsUseCase;
        this._saveAssessmentResultUseCase = saveAssessmentResultUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllAssessmentResultsUseCase _getAllAssessmentResultsUseCase;
    readonly ISaveAssessmentResultUseCase _saveAssessmentResultUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Tasks
    public async Task ExecuteAsync(List<AssessmentResultUseCaseModel> list, bool commit = false)
    {
        if (list?.Any() ?? false)
        {
            var useCaseModels = await this._getAllAssessmentResultsUseCase.ExecuteAsync();
            for (int itemIndex = 0; itemIndex < list.Count; itemIndex++)
            {
                var currentItem = list[itemIndex];
                if (currentItem != null)
                {
                    string? currentEmailItem = currentItem.Email?.ToLower(), currentNickNameItem = currentItem.NickName?.ToLower();
                    string? currentUserNameItem = currentItem.UserName?.ToLower();
                    var foundUseCaseModel = useCaseModels.FirstOrDefault(e => (!string.IsNullOrEmpty(e.Email)) && (e.Email?.ToLower() == currentEmailItem) ||
                                                                              (!string.IsNullOrEmpty(e.NickName)) && (e.NickName?.ToLower() == currentNickNameItem) ||
                                                                              (!string.IsNullOrEmpty(e.UserName)) && (e.UserName?.ToLower() == currentUserNameItem));

                    if (foundUseCaseModel == null)
                        await this._saveAssessmentResultUseCase.ExecuteAsync(currentItem, false);
                }
            }
            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Tasks
}
