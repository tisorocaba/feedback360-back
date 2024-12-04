using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Domain.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class ImmediateLeaderDraft
    : DomainModelBase<Guid>
{
    #region Methods
    private void AddQuestionWithAnswer(ImmediateLeader immediateLeader, List<LeadershipQuestion>? questions, string questionKey, string? answer)
    {
        if ((immediateLeader != null) && (questions?.Any() ?? false) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            var gotQuestion = questions.FirstOrDefault(q => q.Abbreviation == questionKey);
            immediateLeader.QuestionsAndAnswers.Add(new QuestionAnswer()
            {
                Key = questionKey,
                KeyType = LuckyDrawDomainConstants.ImmediateLeaderEvaluatedPersonChar,
                Question = this.GetSpecificQuestion(gotQuestion),
                Answer = answer
            });
        }
    }

    private string GetSpecificQuestion(LeadershipQuestion? leadershipQuestion)
    {
        return leadershipQuestion?.Question ?? string.Empty;
    }

    public ImmediateLeader ToOfficial(List<LeadershipQuestion>? questions = null)
    {
        var immediateLeader = new ImmediateLeader()
        {
            Author = this.Author,
            Leader = this.Leader
        };
        immediateLeader.SetId(this.Id);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC43AttributeName, this.Answer01);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC44AttributeName, this.Answer02);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC45AttributeName, this.Answer03);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC46AttributeName, this.Answer04);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC47AttributeName, this.Answer05);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC48AttributeName, this.Answer06);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC49AttributeName, this.Answer07);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC50AttributeName, this.Answer08);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC51AttributeName, this.Answer09);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC52AttributeName, this.Answer10);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC53AttributeName, this.Answer11);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC54AttributeName, this.Answer12);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC55AttributeName, this.Answer13);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC56AttributeName, this.Answer14);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC57AttributeName, this.Answer15);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC58AttributeName, this.Answer16);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC59AttributeName, this.Answer17);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC60AttributeName, this.Answer18);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC61AttributeName, this.Answer19);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC62AttributeName, this.Answer20);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC63AttributeName, this.Answer21);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC64AttributeName, this.Answer22);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC65AttributeName, this.Answer23);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC66AttributeName, this.Answer24);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC67AttributeName, this.Answer25);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC68AttributeName, this.Answer26);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC69AttributeName, this.Answer27);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC70AttributeName, this.Answer28);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC71AttributeName, this.Answer29);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC72AttributeName, this.Answer30);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC73AttributeName, this.Answer31);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC74AttributeName, this.Answer32);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC75AttributeName, this.Answer33);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC76AttributeName, this.Answer34);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC77AttributeName, this.Answer35);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC78AttributeName, this.Answer36);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC79AttributeName, this.Answer37);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC80AttributeName, this.Answer38);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC81AttributeName, this.Answer39);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC82AttributeName, this.Answer40);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC83AttributeName, this.Answer41);
        this.AddQuestionWithAnswer(immediateLeader, questions, InfraDataMongoDBConstants.QC84AttributeName, this.Answer42);
        immediateLeader.Calculate();
        return immediateLeader;
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
