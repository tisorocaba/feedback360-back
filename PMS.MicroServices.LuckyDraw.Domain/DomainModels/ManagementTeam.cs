using PMS.Core.Domain.DomainModels.Base;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class ManagementTeam
    : DomainModelBase<Guid>
{
    #region Constructors
    public ManagementTeam()
    {
        this.QuestionsAndAnswers = new List<QuestionAnswer>(40);
    }
    #endregion Constructors

    #region Properties
    public string? Author { get; set; }
    public string? MediateLeader { get; set; }
    public string? ImmediateLeader { get; set; }

    public List<QuestionAnswer> QuestionsAndAnswers { get; set; }
    #endregion Properties
}
