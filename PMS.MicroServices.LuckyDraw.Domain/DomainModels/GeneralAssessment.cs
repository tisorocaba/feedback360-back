using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using System.Text;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class GeneralAssessment
    : DomainModelBase<Guid>
{
    #region Constants
    public GeneralAssessment()
    {
        this.FreeWritingData = new List<string>(20);
        this.MultipleChoiceData = new List<string>(20);
    }
    #endregion Constants

    #region Constants
    const string SelecioneString = "selecione";
    #endregion Constants

    #region Methods
    public void AddFreeWritingQuestion(QuestionAnswer? questionWithAnswer)
    {
        if ((this.FreeWritingData != null) && (questionWithAnswer?.QuestionType == QuestionTypeEnum.FreeWriting))
        {
            if (!string.IsNullOrWhiteSpace(questionWithAnswer.Answer))
                this.FreeWritingData.Add(questionWithAnswer.Answer.Trim());
        }
    }

    public void AddMultipleChoiceQuestion(QuestionAnswer? questionWithAnswer)
    {
        if ((this.MultipleChoiceData != null) && (questionWithAnswer?.QuestionType == QuestionTypeEnum.MultipleChoice))
        {
            if (!string.IsNullOrWhiteSpace(questionWithAnswer.Answer))
                this.MultipleChoiceData.Add(questionWithAnswer.Answer.Trim());
        }
    }

    public string? ToFreeWritingHtmlCode()
    {
        string? htmlScript;
        if (this.FreeWritingData?.Any() ?? false)
        {
            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("<ul>");
            foreach (var freeWriting in this.FreeWritingData)
            {
                if (!string.IsNullOrWhiteSpace(freeWriting))
                {
                    strBuilder.AppendLine($" <li>{freeWriting.Trim()}</li>");
                }
            }
            strBuilder.AppendLine("</ul>");
            htmlScript = strBuilder.ToString().Trim();
        }
        else
            htmlScript = null;
        return htmlScript;
    }
    #endregion Methods

    #region Properties
    public bool AccessedAsManager { get; set; }
    public string Name { get; set; } = default!;
    public string NickName { get; set; } = default!;
    public string? Key { get; set; }
    public char? KeyType { get; set; }
    public string? Question { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }

    public bool IsFreeWritingQuestion { get { return QuestionType == QuestionTypeEnum.FreeWriting; } }
    public bool IsMultipleChoiceQuestion { get { return QuestionType == QuestionTypeEnum.MultipleChoice; } }

    public QuestionAnswer? SelfAssessmentQuestion { get; set; }
    public QuestionAnswer? SubordinateQuestion { get; set; }
    public QuestionAnswer? SubordinateAverageQuestion { get; set; }
    public QuestionAnswer? CoWorker1Question { get; set; }
    public QuestionAnswer? CoWorker2Question { get; set; }
    public QuestionAnswer? CoWorker3Question { get; set; }
    public QuestionAnswer? CoWorkersAverageQuestion { get; set; }
    public QuestionAnswer? ExtraCoWorkersQuestion { get; set; }
    public QuestionAnswer? ImmediateLeaderAverageQuestion { get; set; }
    public QuestionAnswer? MediateLeaderAverageQuestion { get; set; }
    public QuestionAnswer? OtherImmediateLeadersAverageQuestion { get; set; }
    public QuestionAnswer? OtherMediateLeadersAverageQuestion { get; set; }

    public List<QuestionAnswer>? CoWorkersAverageData { get; set; }
    public List<QuestionAnswer>? ExtraCoWorkersData { get; set; }
    public List<QuestionAnswer>? ImmediateLeaderAverageData { get; set; }
    public List<QuestionAnswer>? MediateLeaderAverageData { get; set; }
    public List<QuestionAnswer>? OtherImmediateLeadersAverageData { get; set; }
    public List<QuestionAnswer>? OtherMediateLeadersAverageData { get; set; }
    public List<QuestionAnswer>? SubordinateAverageData { get; set; }
    public List<string>? FreeWritingData { get; private set; }
    public List<string>? MultipleChoiceData { get; private set; }
    #endregion Properties
}
