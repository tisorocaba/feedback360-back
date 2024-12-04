using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using PMS.MicroServices.LuckyDraw.Domain.Constants;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class QuestionAnswer
{
    #region Constants
    public QuestionAnswer()
    {
        this.KeyType = LuckyDrawDomainConstants.NormalEvaluatedPersonChar;
    }
    #endregion Constants

    #region Properties
    public string Key { get; set; } = default!;
    public char? KeyType;
    public string Question { get; set; } = default!;
    public QuestionTypeEnum QuestionType { get; set; }
    public string? Answer { get; set; } = default!;
    public object? Value { get; set; }

    public bool IsFreeWritingQuestion { get { return this.QuestionType == QuestionTypeEnum.FreeWriting; } }
    public bool IsMeasurableQuestion { get { return this.QuestionType == QuestionTypeEnum.Measurable; } }
    public bool IsMultipleChoiceQuestion { get { return this.QuestionType == QuestionTypeEnum.MultipleChoice; } }
    #endregion Properties
}
