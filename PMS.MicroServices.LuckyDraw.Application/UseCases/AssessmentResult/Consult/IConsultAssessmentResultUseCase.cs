namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IConsultAssessmentResultUseCase
{
    Task<AssessmentResultUseCaseModel?> ExecuteAsync(string userNameOrEmail, string code);
}
