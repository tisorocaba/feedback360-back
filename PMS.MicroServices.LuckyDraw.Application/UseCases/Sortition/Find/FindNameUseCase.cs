namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindNameUseCase
    : IFindNameUseCase
{
    #region Constructors
    public FindNameUseCase(IGetAllAssessmentResultsUseCase getAllAssessmentResultsUseCase)
    {
        this._getAllAssessmentResultsUseCase = getAllAssessmentResultsUseCase;
    }
    #endregion Constructors

    #region Fields
    readonly IGetAllAssessmentResultsUseCase _getAllAssessmentResultsUseCase;
    #endregion Fields

    #region Tasks
    public async Task<List<string>> ExecuteAsync()
    {
        var allAssessmentResults = await this._getAllAssessmentResultsUseCase.ExecuteAsync();
        return allAssessmentResults.Where(a => (!string.IsNullOrEmpty(a.Name))).Select(s => s.Name.Trim()).ToList();
    }
    #endregion Tasks
}
