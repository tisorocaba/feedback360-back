using Mapster;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModels;

namespace PMS.MicroServices.LuckyDraw.Domain.AdapterConfigurations;

public class DomainModelAdapterConfiguration
{
    #region Methods
    public static TypeAdapterConfig GetAdapterConfig()
    {
        var adapterConfig = new TypeAdapterConfig();
        #region Domain To Data
        adapterConfig.NewConfig<AssessmentResult, AssessmentResultDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Author, AuthorMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<CoWorker, CoWorkerMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResult, EvaluationResultDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItem, EvaluationResultItemDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Evaluator, EvaluatorDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralQuestion, GeneralQuestionMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ImmediateLeader, ImmediateLeaderMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<LeadershipQuestion, LeadershipQuestionMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ManagementQuestion, ManagementQuestionMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ManagementTeam, ManagementTeamMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<MediateLeader, MediateLeaderMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Question, QuestionDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SelfAssessment, SelfAssessmentMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Sortition, SortitionDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipant, SortitionParticipantDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantPrinting, SortitionParticipantPrintingDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Subordinate, SubordinateMongoDbDataModel>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Team, TeamDataModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion UseCase To Domain

        #region Data To Domain
        adapterConfig.NewConfig<AssessmentResultDataModel, AssessmentResult>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<AuthorMongoDbDataModel, Author>()
                     .Ignore(i => i.Id)
                     .Ignore(i => i.HasImmediateSubordinates)
                     .Ignore(i => i.HasMediateSubordinates)
                     .Ignore(i => i.BelongsToManagementTeam)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .AfterMapping((src, dest) => dest.SetEquivalentBoolean(nameof(AuthorMongoDbDataModel.HasImmediateSubordinates), src.HasImmediateSubordinates))
                     .AfterMapping((src, dest) => dest.SetEquivalentBoolean(nameof(AuthorMongoDbDataModel.HasMediateSubordinates), src.HasMediateSubordinates))
                     .AfterMapping((src, dest) => dest.SetEquivalentBoolean(nameof(AuthorMongoDbDataModel.BelongsToManagementTeam), src.BelongsToManagementTeam))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<CoWorkerMongoDbDataModel, CoWorker>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<CoWorkerMongoDbDataModel, CoWorkerDraft>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultDataModel, EvaluationResult>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItemDataModel, EvaluationResultItem>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorDataModel, Evaluator>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralQuestionMongoDbDataModel, GeneralQuestion>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ImmediateLeaderMongoDbDataModel, ImmediateLeader>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ImmediateLeaderMongoDbDataModel, ImmediateLeaderDraft>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<LeadershipQuestionMongoDbDataModel, LeadershipQuestion>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ManagementQuestionMongoDbDataModel, ManagementQuestion>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ManagementTeamMongoDbDataModel, ManagementTeamDraft>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<ManagementTeamMongoDbDataModel, ManagementTeam>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<MediateLeaderMongoDbDataModel, MediateLeader>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<MediateLeaderMongoDbDataModel, MediateLeaderDraft>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<QuestionDataModel, Question>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SelfAssessmentMongoDbDataModel, SelfAssessmentDraft>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SelfAssessmentMongoDbDataModel, SelfAssessment>()
                     .Ignore(i => i.Id)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionDataModel, Sortition>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantDataModel, SortitionParticipant>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantPrintingDataModel, SortitionParticipantPrinting>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SubordinateMongoDbDataModel, SubordinateDraft>()
                     .Ignore(i => i.Id)
                     .Ignore(i => i.HasSubordinates)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .AfterMapping((src, dest) => dest.SetEquivalentBoolean(nameof(SubordinateMongoDbDataModel.HasSubordinates), src.HasSubordinates))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SubordinateMongoDbDataModel, Subordinate>()
                     .Ignore(i => i.Id)
                     .Ignore(i => i.HasSubordinates)
                     .AfterMapping((src, dest) => dest.SetIdByObjectId(src?.Id))
                     .AfterMapping((src, dest) => dest.SetEquivalentBoolean(nameof(SubordinateMongoDbDataModel.HasSubordinates), src.HasSubordinates))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<TeamDataModel, Team>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion Domain To UseCase
        return adapterConfig;
    }
    #endregion Methods
}
