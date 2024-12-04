using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISendBatchOfAssessmentResultMailsUseCase
{
    Task ExecuteAsync(LuckyDrawAppConfiguration config, List<AssessmentResultUseCaseModel> list);
}
