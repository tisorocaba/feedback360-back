using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface ISortitionResultDomainService
{
    #region Tasks
    Task<List<GeneralAssessment>> FindOutAsync(string nickname, string userNameOrEmail, string code, string? evaluatedPersonName = null);
    #endregion Tasks
}
