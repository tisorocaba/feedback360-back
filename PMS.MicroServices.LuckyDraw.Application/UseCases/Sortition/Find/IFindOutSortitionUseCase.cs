using PMS.MicroServices.LuckyDraw.Application.Models;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public interface IFindOutSortitionUseCase
{
    Task<List<GeneralAssessmentUseCaseModel>> ExecuteAsync(string nickname, string userNameOrEmail, string code, string? evaluatedPersonName = null);
}
