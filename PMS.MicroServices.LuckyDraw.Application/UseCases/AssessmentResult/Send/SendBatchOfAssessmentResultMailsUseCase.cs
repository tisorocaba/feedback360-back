using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Messages;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SendBatchOfAssessmentResultMailsUseCase
    : UseCaseBase,
    ISendBatchOfAssessmentResultMailsUseCase
{
    #region Constructors
    public SendBatchOfAssessmentResultMailsUseCase(IGetAllAssessmentResultsUseCase getAllAssessmentResultsUseCase, ISendAssessmentResultMailUseCase sendAssessmentResultMailUseCase)
    {
        this._getAllAssessmentResultsUseCase = getAllAssessmentResultsUseCase;
        this._sendAssessmentResultMailUseCase = sendAssessmentResultMailUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllAssessmentResultsUseCase _getAllAssessmentResultsUseCase;
    readonly ISendAssessmentResultMailUseCase _sendAssessmentResultMailUseCase;
    #endregion Fields

    #region Methods
    private SendAssessmentResultMailRequestMessage BindSendAssessmentResultMailRequestMessage(AssessmentResultUseCaseModel useCaseModel)
    {
        return new SendAssessmentResultMailRequestMessage()
        {
            Name  = useCaseModel.Name,
            UserName = useCaseModel.UserName,
            Email = useCaseModel.Email,
            Code = useCaseModel.Code,
            TargetUrl = "http://172.16.9.64:50083/resultados"
        };
    }
    #endregion Methods

    #region Tasks
    public async Task ExecuteAsync(LuckyDrawAppConfiguration config, List<AssessmentResultUseCaseModel> list)
    {
        if (list?.Any() ?? false)
        {
            foreach (var currentItem in list)
            {
                if (currentItem != null)
                    await this._sendAssessmentResultMailUseCase.ExecuteAsync(config, this.BindSendAssessmentResultMailRequestMessage(currentItem));
            }
        }
    }
    #endregion Tasks
}
