namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface ISaveAssessmentResultUseCase
{
    Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false);
}
