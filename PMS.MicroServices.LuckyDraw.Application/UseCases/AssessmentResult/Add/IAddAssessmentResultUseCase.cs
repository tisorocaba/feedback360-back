namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IAddAssessmentResultUseCase
{
    Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false);
}
