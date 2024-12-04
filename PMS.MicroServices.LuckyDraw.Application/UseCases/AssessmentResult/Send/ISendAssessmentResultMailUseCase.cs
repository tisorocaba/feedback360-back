using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Messages;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISendAssessmentResultMailUseCase
{
    Task<SendAssessmentResultMailResponseMessage> ExecuteAsync(LuckyDrawAppConfiguration config, SendAssessmentResultMailRequestMessage requestMessage);
}
