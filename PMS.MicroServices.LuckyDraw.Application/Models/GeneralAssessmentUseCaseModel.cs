using PMS.Core.Application.Models.Base;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Enums;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.Models;

public class GeneralAssessmentUseCaseModel
    : UseCaseModelBase<Guid, GeneralAssessmentUseCaseModel>
{
    #region Methods
    public override void Bind(GeneralAssessmentUseCaseModel source)
    {

    }

    private bool HasAssignableText(QuestionAnswer? questionWithAnswer)
    {
        bool hasAssignableText = false;
        if (questionWithAnswer != null)
            hasAssignableText = !((questionWithAnswer.IsFreeWritingQuestion &&
                                  (questionWithAnswer.Answer?.Trim().ToUpper() == Domain.Resources.LuckyDrawDomainResource.NO_EVALUATION.ToUpper())));
        return hasAssignableText;
    }

    public void SetCoWorker1(QuestionAnswer? coWorker1QuestionWithAnswer)
    {
        if (coWorker1QuestionWithAnswer != null)
        {
            if (this.HasAssignableText(coWorker1QuestionWithAnswer))
                this.CoWorker1AnswerText = coWorker1QuestionWithAnswer.Answer;
            if (coWorker1QuestionWithAnswer.Value != null)
                this.CoWorker1AnswerValue = (int)coWorker1QuestionWithAnswer.Value;
        }
    }

    public void SetCoWorker2(QuestionAnswer? coWorker2QuestionWithAnswer)
    {
        if (coWorker2QuestionWithAnswer != null)
        {
            if (this.HasAssignableText(coWorker2QuestionWithAnswer))
                this.CoWorker2AnswerText = coWorker2QuestionWithAnswer.Answer;
            if (coWorker2QuestionWithAnswer.Value != null)
                this.CoWorker2AnswerValue = (int)coWorker2QuestionWithAnswer.Value;
        }
    }

    public void SetCoWorker3(QuestionAnswer? coWorker3QuestionWithAnswer)
    {
        if (coWorker3QuestionWithAnswer != null)
        {
            if (this.HasAssignableText(coWorker3QuestionWithAnswer))
                this.CoWorker3AnswerText = coWorker3QuestionWithAnswer.Answer;
            if (coWorker3QuestionWithAnswer.Value != null)
                this.CoWorker3AnswerValue = (int)coWorker3QuestionWithAnswer.Value;
        }
    }

    public void SetCoWorkersAverage(QuestionAnswer? coWorkersAverageQuestionWithAnswer)
    {
        if (coWorkersAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(coWorkersAverageQuestionWithAnswer))
                this.CoWorkersAverageAnswerText = coWorkersAverageQuestionWithAnswer.Answer;
            if (coWorkersAverageQuestionWithAnswer.Value != null)
            {
                if (coWorkersAverageQuestionWithAnswer.Value is Enum)
                    this.CoWorkersAverageAnswerValue = (int)coWorkersAverageQuestionWithAnswer.Value;
            }
        }
    }

    public void SetExtraCoWorkers(QuestionAnswer? extraCoWorkersQuestionWithAnswer)
    {
        if (extraCoWorkersQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(extraCoWorkersQuestionWithAnswer))
                this.ExtraCoWorkersAnswerText = extraCoWorkersQuestionWithAnswer.Answer;
            if (extraCoWorkersQuestionWithAnswer.Value != null)
            {
                if (extraCoWorkersQuestionWithAnswer.Value is Enum)
                    this.ExtraCoWorkersAnswerValue = (int)extraCoWorkersQuestionWithAnswer.Value;
            }
        }
    }

    public void SetImmediateLeaderAverage(QuestionAnswer? immediateLeaderAverageQuestionWithAnswer)
    {
        if (immediateLeaderAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(immediateLeaderAverageQuestionWithAnswer))
                this.ImmediateLeaderAverageAnswerText = immediateLeaderAverageQuestionWithAnswer.Answer;
            if (immediateLeaderAverageQuestionWithAnswer.Value != null)
            {
                if (immediateLeaderAverageQuestionWithAnswer.Value is Enum)
                    this.ImmediateLeaderAverageAnswerValue = (int)immediateLeaderAverageQuestionWithAnswer.Value;
            }
        }
    }

    public void SetMediateLeaderAverage(QuestionAnswer? mediateLeaderAverageQuestionWithAnswer)
    {
        if (mediateLeaderAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(mediateLeaderAverageQuestionWithAnswer))
                this.MediateLeaderAverageAnswerText = mediateLeaderAverageQuestionWithAnswer.Answer;
            if (mediateLeaderAverageQuestionWithAnswer.Value != null)
            {
                if (mediateLeaderAverageQuestionWithAnswer.Value is Enum)
                    this.MediateLeaderAverageAnswerValue = (int)mediateLeaderAverageQuestionWithAnswer.Value;
            }
        }
    }

    public void SetOtherImmediateLeadersAverage(QuestionAnswer? otherImmediateLeadersAverageQuestionWithAnswer)
    {
        if (otherImmediateLeadersAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(otherImmediateLeadersAverageQuestionWithAnswer))
                this.OtherImmediateLeadersAverageAnswerText = otherImmediateLeadersAverageQuestionWithAnswer.Answer;
            if (otherImmediateLeadersAverageQuestionWithAnswer.Value != null)
            {
                if (otherImmediateLeadersAverageQuestionWithAnswer.Value is Enum)
                    this.OtherImmediateLeadersAverageAnswerValue = (int)otherImmediateLeadersAverageQuestionWithAnswer.Value;
            }
        }
    }

    public void SetOtherMediateLeadersAverage(QuestionAnswer? otherMediateLeadersAverageQuestionWithAnswer)
    {
        if (otherMediateLeadersAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(otherMediateLeadersAverageQuestionWithAnswer))
                this.OtherMediateLeadersAverageAnswerText = otherMediateLeadersAverageQuestionWithAnswer.Answer;
            if (otherMediateLeadersAverageQuestionWithAnswer.Value != null)
            {
                if (otherMediateLeadersAverageQuestionWithAnswer.Value is Enum)
                    this.OtherMediateLeadersAverageAnswerValue = (int)otherMediateLeadersAverageQuestionWithAnswer.Value;
            }
        }
    }

    public void SetSelfAssessment(QuestionAnswer? selfAssessmentQuestionWithAnswer)
    {
        if (selfAssessmentQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(selfAssessmentQuestionWithAnswer))
                this.SelfAssessmentAnswerText = selfAssessmentQuestionWithAnswer.Answer;
            if (selfAssessmentQuestionWithAnswer.Value != null)
                this.SelfAssessmentAnswerValue = (int)selfAssessmentQuestionWithAnswer.Value;
        }
    }

    public void SetSubordinate(QuestionAnswer? subordinateQuestionWithAnswer)
    {
        if (subordinateQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(subordinateQuestionWithAnswer))
                this.SubordinateAnswerText = subordinateQuestionWithAnswer.Answer;
            if (subordinateQuestionWithAnswer.Value != null)
                this.SubordinateAnswerValue = (int)subordinateQuestionWithAnswer.Value;
        }
    }

    public void SetSubordinateAverage(QuestionAnswer? subordinateAverageQuestionWithAnswer)
    {
        if (subordinateAverageQuestionWithAnswer != null)
        {
            if (this.HasAssignableText(subordinateAverageQuestionWithAnswer))
                this.SubordinateAverageAnswerText = subordinateAverageQuestionWithAnswer.Answer;
            if (subordinateAverageQuestionWithAnswer.Value != null)
            {
                if (subordinateAverageQuestionWithAnswer.Value is Enum)
                    this.SubordinateAverageAnswerValue = (int)subordinateAverageQuestionWithAnswer.Value;
            }
        }
    }
    #endregion Methods

    #region Properties
    public bool AccessedAsManager { get; set; }
    public bool IsMultipleChoiceQuestion { get; set; }
    public string? Name { get; set; }
    public string? NickName { get; set; }
    public string? Key { get; set; }
    public char? KeyType { get; set; }
    public string? Question { get; set; }
    public QuestionTypeEnum QuestionType { get; set; }
    public string? SelfAssessmentAnswerText { get; set; }
    public decimal? SelfAssessmentAnswerValue { get; set; }
    public string? SubordinateAnswerText { get; set; }
    public decimal? SubordinateAnswerValue { get; set; }
    public string? SubordinateAverageAnswerText { get; set; }
    public decimal? SubordinateAverageAnswerValue { get; set; }
    public string? CoWorker1AnswerText { get; set; }
    public decimal? CoWorker1AnswerValue { get; set; }
    public string? CoWorker2AnswerText { get; set; }
    public decimal? CoWorker2AnswerValue { get; set; }
    public string? CoWorker3AnswerText { get; set; }
    public decimal? CoWorker3AnswerValue { get; set; }
    public string? CoWorkersAverageAnswerText { get; set; }
    public decimal? CoWorkersAverageAnswerValue { get; set; }
    public string? ExtraCoWorkersAnswerText { get; set; }
    public decimal? ExtraCoWorkersAnswerValue { get; set; }
    public string? ImmediateLeaderAverageAnswerText { get; set; }
    public decimal? ImmediateLeaderAverageAnswerValue { get; set; }
    public string? MediateLeaderAverageAnswerText { get; set; }
    public decimal? MediateLeaderAverageAnswerValue { get; set; }
    public string? OtherImmediateLeadersAverageAnswerText { get; set; }
    public decimal? OtherImmediateLeadersAverageAnswerValue { get; set; }
    public string? OtherMediateLeadersAverageAnswerText { get; set; }
    public decimal? OtherMediateLeadersAverageAnswerValue { get; set; }

    public List<QuestionAnswer>? CoWorkersAverageData { get; set; }
    public List<QuestionAnswer>? ExtraCoWorkersData { get; set; }
    public List<QuestionAnswer>? ImmediateLeaderAverageData { get; set; }
    public List<QuestionAnswer>? MediateLeaderAverageData { get; set; }
    public List<QuestionAnswer>? OtherImmediateLeadersAverageData { get; set; }
    public List<QuestionAnswer>? OtherMediateLeadersAverageData { get; set; }
    public List<QuestionAnswer>? SubordinateAverageData { get; set; }
    public List<string>? FreeWritingData { get; private set; }
    public List<string>? MultipleChoiceData { get; set; }
    #endregion Properties
}
