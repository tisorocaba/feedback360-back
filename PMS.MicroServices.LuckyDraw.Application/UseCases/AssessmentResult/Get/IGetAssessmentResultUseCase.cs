namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAssessmentResultUseCase
{
    Task<AssessmentResultUseCaseModel?> ExecuteAsync(Guid id);
}
