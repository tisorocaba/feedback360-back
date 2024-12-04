using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Application.UseCases;
using PMS.MicroServices.LuckyDraw.Service.Models;

namespace PMS.MicroServices.LuckyDraw.Service.AdapterConfigurations;

public class ServiceModelAdapterConfiguration
{
    #region Methods
    public static TypeAdapterConfig GetAdapterConfig()
    {
        var adapterConfig = new TypeAdapterConfig();
        #region Service To UseCase
        adapterConfig.NewConfig<AssessmentResultServiceModel, AssessmentResultUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultServiceModel, EvaluationResultUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItemServiceModel, EvaluationResultItemUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorServiceModel, EvaluatorUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralAssessmentServiceModel, GeneralAssessmentUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<NickNameServiceModel, NickNameUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<QuestionServiceModel, QuestionUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantServiceModel, SortitionParticipantUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionServiceModel, SortitionUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<TeamServiceModel, TeamUseCaseModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion Service To UseCase

        #region UseCase To Service
        adapterConfig.NewConfig<AssessmentResultUseCaseModel, AssessmentResultServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultItemUseCaseModel, EvaluationResultItemServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluationResultUseCaseModel, EvaluationResultServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorUseCaseModel, EvaluatorServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorUseCaseModel, NameServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<EvaluatorUseCaseModel, NickNameServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<GeneralAssessmentUseCaseModel, GeneralAssessmentServiceModel>()
                     .AfterMapping((src, dest) => dest.SetCoWorkersAverageChartData(src.CoWorkersAverageData))
                     .AfterMapping((src, dest) => dest.SetExtraCoWorkersChartData(src.ExtraCoWorkersData))
                     .AfterMapping((src, dest) => dest.SetSubordinateAverageChartData(src.SubordinateAverageData))
                     .AfterMapping((src, dest) => dest.SetImmediateLeaderAverageChartData(src.ImmediateLeaderAverageData))
                     .AfterMapping((src, dest) => dest.SetOtherImmediateLeadersAverageChartData(src.OtherImmediateLeadersAverageData))
                     .AfterMapping((src, dest) => dest.SetMediateLeaderAverageChartData(src.MediateLeaderAverageData))
                     .AfterMapping((src, dest) => dest.SetOtherMediateLeadersAverageChartData(src.OtherMediateLeadersAverageData))
                     .AfterMapping((src, dest) => dest.SetMultipleChoiceChartData(src.MultipleChoiceData, src.Key))
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<NameUseCaseModel, NameServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<NickNameUseCaseModel, NickNameServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<QuestionUseCaseModel, QuestionServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionParticipantUseCaseModel, SortitionParticipantServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<SortitionUseCaseModel, SortitionServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);

        adapterConfig.NewConfig<TeamUseCaseModel, TeamServiceModel>()
                     .IgnoreNullValues(true)
                     .PreserveReference(true);
        #endregion UseCase To Service
        return adapterConfig;
    }
    #endregion Methods
}
