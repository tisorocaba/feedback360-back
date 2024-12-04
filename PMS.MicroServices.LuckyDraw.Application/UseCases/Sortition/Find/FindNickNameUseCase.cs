using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindNickNameUseCase
    : IFindNickNameUseCase
{
    #region Constructors
    public FindNickNameUseCase(IAuthorDomainService authorDomainService, ISelfAssessmentDomainService selfAssessmentDomainService)
    {
        this._authorDomainService = authorDomainService;
        this._selfAssessmentDomainService = selfAssessmentDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IAuthorDomainService _authorDomainService;
    readonly ISelfAssessmentDomainService _selfAssessmentDomainService;
    #endregion Fields

    #region Tasks
    public async Task<List<string>> ExecuteAsync()
    {
        var authors = await this._authorDomainService.GetAllAsync();
        var authorNames = (authors?.Select(m => m.NickName ?? string.Empty)?.Distinct()?.ToList() ?? new List<string>(0));

        var selfAssessments = await this._selfAssessmentDomainService.GetAllAsync();
        var selfAssessmentAuthors = (selfAssessments?.Select(m => m.Author ?? string.Empty)?.Distinct()?.ToList() ?? new List<string>(0));

        var tempNames = new List<string>(authorNames.Count + selfAssessmentAuthors.Count);
        tempNames.AddRange(authorNames);
        tempNames.AddRange(selfAssessmentAuthors);

        var nicknames = tempNames.Where(n => !string.IsNullOrEmpty(n)).Distinct().ToList();
        nicknames.Sort();
        return nicknames;
    }
    #endregion Tasks
}
