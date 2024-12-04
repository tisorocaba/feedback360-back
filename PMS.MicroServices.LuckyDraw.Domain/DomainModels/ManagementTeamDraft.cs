using PMS.Core.Domain.DomainModels.Base;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.Constants;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainModels;

public class ManagementTeamDraft
    : DomainModelBase<Guid>
{
    #region Methods
    private void AddQuestionWithAnswer(ManagementTeam managementTeam, List<ManagementQuestion>? questions, string questionKey, string? answer)
    {
        if ((managementTeam != null) && (questions?.Any() ?? false) && (!string.IsNullOrWhiteSpace(questionKey)))
        {
            var gotQuestion = questions.FirstOrDefault(q => q.Abbreviation == questionKey);
            managementTeam.QuestionsAndAnswers.Add(new QuestionAnswer()
            {
                Key = questionKey,
                Question = this.GetSpecificQuestion(gotQuestion),
                Answer = answer
            });
        }
    }

    private string GetSpecificQuestion(ManagementQuestion? generalQuestion)
    {
        return generalQuestion?.Question ?? string.Empty;
    }

    public ManagementTeam ToOfficial(List<ManagementQuestion>? questions = null)
    {
        var managementTeam = new ManagementTeam()
        {
            Author = this.Author,
            ImmediateLeader = this.ImmediateLeader,
            MediateLeader = this.MediateLeader
        };
        managementTeam.SetId(this.Id);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG01AttributeName, this.Answer01);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG02AttributeName, this.Answer02);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG03AttributeName, this.Answer03);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG04AttributeName, this.Answer04);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG05AttributeName, this.Answer05);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG06AttributeName, this.Answer06);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG07AttributeName, this.Answer07);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG08AttributeName, this.Answer08);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG09AttributeName, this.Answer09);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG10AttributeName, this.Answer10);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG11AttributeName, this.Answer11);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG12AttributeName, this.Answer12);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG13AttributeName, this.Answer13);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG14AttributeName, this.Answer14);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG15AttributeName, this.Answer15);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG16AttributeName, this.Answer16);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG17AttributeName, this.Answer17);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG18AttributeName, this.Answer18);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG19AttributeName, this.Answer19);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG20AttributeName, this.Answer20);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG21AttributeName, this.Answer21);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG22AttributeName, this.Answer22);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG23AttributeName, this.Answer23);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG24AttributeName, this.Answer24);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG25AttributeName, this.Answer25);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG26AttributeName, this.Answer26);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG27AttributeName, this.Answer27);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG28AttributeName, this.Answer28);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG29AttributeName, this.Answer29);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG30AttributeName, this.Answer30);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG31AttributeName, this.Answer31);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG32AttributeName, this.Answer32);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG33AttributeName, this.Answer33);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG34AttributeName, this.Answer34);
        this.AddQuestionWithAnswer(managementTeam, questions, InfraDataMongoDBConstants.QG35AttributeName, this.Answer35);
        return managementTeam;
    }
    #endregion Methods

    #region Properties
    public string? Author { get; set; }
    public string? MediateLeader { get; set; }
    public string? ImmediateLeader { get; set; }
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
    #endregion Properties
}