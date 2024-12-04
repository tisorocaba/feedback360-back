using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Application.UseCases;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.AdapterConfigurations;

public class UseCaseModelAdapterConfiguration
{
    #region Methods
    public static TypeAdapterConfig GetAdapterConfig()
    {
        var adapterConfig = new TypeAdapterConfig();
        #region UseCase To Domain
        adapterConfig.NewConfig<AssessmentResultUseCaseModel, AssessmentResult>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<AuthorUseCaseModel, Author>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItemUseCaseModel, EvaluationResultItem>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultUseCaseModel, EvaluationResult>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorUseCaseModel, Evaluator>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralAssessmentUseCaseModel, GeneralAssessment>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<QuestionUseCaseModel, Question>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantUseCaseModel, SortitionParticipant>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionUseCaseModel, Sortition>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<TeamUseCaseModel, Team>()
                     .AfterMapping((src, dest) => dest.SetId(src.Id))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion UseCase To Domain

        #region Domain To UseCase
        adapterConfig.NewConfig<AssessmentResult, AssessmentResultUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Author, AuthorUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItem, EvaluationResultItemUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResult, EvaluationResultUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Evaluator, EvaluatorUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralAssessment, GeneralAssessmentUseCaseModel>()
                     .AfterMapping((src, dest) => dest.SetSelfAssessment(src.SelfAssessmentQuestion))
                     .AfterMapping((src, dest) => dest.SetSubordinate(src.SubordinateQuestion))
                     .AfterMapping((src, dest) => dest.SetSubordinateAverage(src.SubordinateAverageQuestion))
                     .AfterMapping((src, dest) => dest.SetCoWorker1(src.CoWorker1Question))
                     .AfterMapping((src, dest) => dest.SetCoWorker2(src.CoWorker2Question))
                     .AfterMapping((src, dest) => dest.SetCoWorker3(src.CoWorker3Question))
                     .AfterMapping((src, dest) => dest.SetCoWorkersAverage(src.CoWorkersAverageQuestion))
                     .AfterMapping((src, dest) => dest.SetExtraCoWorkers(src.ExtraCoWorkersQuestion))
                     .AfterMapping((src, dest) => dest.SetImmediateLeaderAverage(src.ImmediateLeaderAverageQuestion))
                     .AfterMapping((src, dest) => dest.SetOtherImmediateLeadersAverage(src.OtherImmediateLeadersAverageQuestion))
                     .AfterMapping((src, dest) => dest.SetMediateLeaderAverage(src.MediateLeaderAverageQuestion))
                     .AfterMapping((src, dest) => dest.SetOtherMediateLeadersAverage(src.OtherMediateLeadersAverageQuestion))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Question, QuestionUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Sortition, SortitionUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipant, SortitionParticipantUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<Team, TeamUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion Domain To UseCase
        return adapterConfig;
    }
    #endregion Methods
}
