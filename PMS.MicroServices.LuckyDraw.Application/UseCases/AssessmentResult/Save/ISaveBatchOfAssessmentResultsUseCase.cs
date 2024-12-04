namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveBatchOfAssessmentResultsUseCase
{
    Task ExecuteAsync(List<AssessmentResultUseCaseModel> list, bool commit = false);
}
