namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IUpdateAssessmentResultUseCase
{
    Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false);
}
