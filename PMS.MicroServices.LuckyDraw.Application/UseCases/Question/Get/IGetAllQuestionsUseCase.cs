namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IGetAllQuestionsUseCase
{
    Task<List<QuestionUseCaseModel>> ExecuteAsync();
}
