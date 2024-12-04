using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class CoWorkerDraft
    : DomainModelBase<Guid>
{
    #region Methods
    private void AddQuestionWithAnswer(CoWorker coWorker, List<GeneralQuestion>? questions, string questionKey, string? answer)
    {
        if ((coWorker != null) && (questions?.Any() ?? false) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            var gotQuestion = questions.FirstOrDefault(q => q.Abbreviation == questionKey);
            var questionWithAnswer = new QuestionAnswer()
            {
                Key = questionKey,
                Question = this.GetSpecificQuestion(gotQuestion),
                Answer = answer
            };
            coWorker.QuestionsAndAnswers.Add(questionWithAnswer);
        }
    }

    private string GetSpecificQuestion(GeneralQuestion? generalQuestion)
    {
        return generalQuestion?.SelfAssessmentQuestion ?? string.Empty;
    }

    public CoWorker ToOfficial(List<GeneralQuestion>? questions = null)
    {
        var coWorker = new CoWorker()
        {
            Author = this.Author,
            EvaluatedCoWorker = this.EvaluatedCoWorker,
            CoWorkerTeam = this.CoWorkerTeam,
            CoWorkerType = this.CoWorkerType
        };
        coWorker.SetId(this.Id);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q01AttributeName, this.Answer01);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q02AttributeName, this.Answer02);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q03AttributeName, this.Answer03);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q04AttributeName, this.Answer04);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q05AttributeName, this.Answer05);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q06AttributeName, this.Answer06);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q07AttributeName, this.Answer07);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q08AttributeName, this.Answer08);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q09AttributeName, this.Answer09);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q10AttributeName, this.Answer10);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q11AttributeName, this.Answer11);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q12AttributeName, this.Answer12);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q13AttributeName, this.Answer13);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q14AttributeName, this.Answer14);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q15AttributeName, this.Answer15);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q16AttributeName, this.Answer16);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q17AttributeName, this.Answer17);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q18AttributeName, this.Answer18);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q19AttributeName, this.Answer19);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q20AttributeName, this.Answer20);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q21AttributeName, this.Answer21);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q22AttributeName, this.Answer22);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q23AttributeName, this.Answer23);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q24AttributeName, this.Answer24);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q25AttributeName, this.Answer25);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q26AttributeName, this.Answer26);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q27AttributeName, this.Answer27);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q28AttributeName, this.Answer28);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q29AttributeName, this.Answer29);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q30AttributeName, this.Answer30);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q31AttributeName, this.Answer31);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q32AttributeName, this.Answer32);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q33AttributeName, this.Answer33);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q34AttributeName, this.Answer34);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q35AttributeName, this.Answer35);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q36AttributeName, this.Answer36);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q37AttributeName, this.Answer37);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q38AttributeName, this.Answer38);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q39AttributeName, this.Answer39);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q40AttributeName, this.Answer40);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q41AttributeName, this.Answer41);
        this.AddQuestionWithAnswer(coWorker, questions, InfraDataMongoDBConstants.Q42AttributeName, this.Answer42);
        coWorker.Calculate();
        return coWorker;
    }
    #endregion Methods

    #region Properties
    public string? Author { get; set; }
    public string? EvaluatedCoWorker { get; set; }
    public string? CoWorkerTeam { get; set; }
    public string? CoWorkerType { get; set; }
    public string? Answer01 { get; set; }
    public string? Answer02 { get; set; }
    public string? Answer03 { get; set; }
    public string? Answer04 { get; set; }
    public string? Answer05 { get; set; }
    public string? Answer06 { get; set; }
    public string? Answer07 { get; set; }
    public string? Answer08 { get; set; }
    public string? Answer09 { get; set; }
    public string? Answer10 { get; set; }
    public string? Answer11 { get; set; }
    public string? Answer12 { get; set; }
    public string? Answer13 { get; set; }
    public string? Answer14 { get; set; }
    public string? Answer15 { get; set; }
    public string? Answer16 { get; set; }
    public string? Answer17 { get; set; }
    public string? Answer18 { get; set; }
    public string? Answer19 { get; set; }
    public string? Answer20 { get; set; }
    public string? Answer21 { get; set; }
    public string? Answer22 { get; set; }
    public string? Answer23 { get; set; }
    public string? Answer24 { get; set; }
    public string? Answer25 { get; set; }
    public string? Answer26 { get; set; }
    public string? Answer27 { get; set; }
    public string? Answer28 { get; set; }
    public string? Answer29 { get; set; }
    public string? Answer30 { get; set; }
    public string? Answer31 { get; set; }
    public string? Answer32 { get; set; }
    public string? Answer33 { get; set; }
    public string? Answer34 { get; set; }
    public string? Answer35 { get; set; }
    public string? Answer36 { get; set; }
    public string? Answer37 { get; set; }
    public string? Answer38 { get; set; }
    public string? Answer39 { get; set; }
    public string? Answer40 { get; set; }
    public string? Answer41 { get; set; }
    public string? Answer42 { get; set; }
    #endregion Properties
}
