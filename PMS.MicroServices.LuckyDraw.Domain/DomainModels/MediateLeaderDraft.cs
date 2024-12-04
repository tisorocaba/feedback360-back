using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class MediateLeaderDraft
    : DomainModelBase<Guid>
{
    #region Methods
    private void AddQuestionWithAnswer(MediateLeader mediateLeader, List<LeadershipQuestion>? questions, string questionKey, string? answer)
    {
        if ((mediateLeader != null) && (questions?.Any() ?? false) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            var gotQuestion = questions.FirstOrDefault(q => q.Abbreviation == questionKey);
            mediateLeader.QuestionsAndAnswers.Add(new QuestionAnswer()
            {
                Key = questionKey,
                KeyType = LuckyDrawDomainConstants.MediateLeaderEvaluatedPersonChar,
                Question = this.GetSpecificQuestion(gotQuestion),
                Answer = answer
            });
        }
    }

    private string GetSpecificQuestion(LeadershipQuestion? leadershipQuestion)
    {
        return leadershipQuestion?.Question ?? string.Empty;
    }

    public MediateLeader ToOfficial(List<LeadershipQuestion>? questions = null)
    {
        var mediateLeader = new MediateLeader()
        {
            Author = this.Author,
            Leader = this.Leader
        };
        mediateLeader.SetId(this.Id);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC01AttributeName, this.Answer01);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC02AttributeName, this.Answer02);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC03AttributeName, this.Answer03);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC04AttributeName, this.Answer04);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC05AttributeName, this.Answer05);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC06AttributeName, this.Answer06);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC07AttributeName, this.Answer07);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC08AttributeName, this.Answer08);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC09AttributeName, this.Answer09);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC10AttributeName, this.Answer10);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC11AttributeName, this.Answer11);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC12AttributeName, this.Answer12);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC13AttributeName, this.Answer13);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC14AttributeName, this.Answer14);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC15AttributeName, this.Answer15);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC16AttributeName, this.Answer16);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC17AttributeName, this.Answer17);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC18AttributeName, this.Answer18);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC19AttributeName, this.Answer19);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC20AttributeName, this.Answer20);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC21AttributeName, this.Answer21);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC22AttributeName, this.Answer22);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC23AttributeName, this.Answer23);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC24AttributeName, this.Answer24);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC25AttributeName, this.Answer25);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC26AttributeName, this.Answer26);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC27AttributeName, this.Answer27);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC28AttributeName, this.Answer28);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC29AttributeName, this.Answer29);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC30AttributeName, this.Answer30);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC31AttributeName, this.Answer31);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC32AttributeName, this.Answer32);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC33AttributeName, this.Answer33);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC34AttributeName, this.Answer34);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC35AttributeName, this.Answer35);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC36AttributeName, this.Answer36);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC37AttributeName, this.Answer37);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC38AttributeName, this.Answer38);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC39AttributeName, this.Answer39);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC40AttributeName, this.Answer40);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC41AttributeName, this.Answer41);
        this.AddQuestionWithAnswer(mediateLeader, questions, InfraDataMongoDBConstants.QC42AttributeName, this.Answer42);
        mediateLeader.Calculate();
        return mediateLeader;
    }
    #endregion Methods

    #region Properties
    public string? Author { get; set; }
    public string? Leader { get; set; }
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
