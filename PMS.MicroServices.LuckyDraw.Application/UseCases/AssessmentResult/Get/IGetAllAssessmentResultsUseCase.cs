namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllAssessmentResultsUseCase
{
    Task<List<AssessmentResultUseCaseModel>> ExecuteAsync();
}
