using Microsoft.Extensions.DependencyInjection;
using PMS.MicroServices.LuckyDraw.Application.UseCases;

namespace PMS.MicroServices.LuckyDraw.Application.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // AssessmentResult
        services.AddScoped<IAddAssessmentResultUseCase, AddAssessmentResultUseCase>();
        services.AddScoped<IConsultAssessmentResultUseCase, ConsultAssessmentResultUseCase>();
        services.AddScoped<IFindOneAssessmentResultUseCase, FindOneAssessmentResultUseCase>();
        services.AddScoped<IGetAllAssessmentResultsUseCase, GetAllAssessmentResultsUseCase>();
        services.AddScoped<IGetAssessmentResultUseCase, GetAssessmentResultUseCase>();
        services.AddScoped<ISaveAssessmentResultUseCase, SaveAssessmentResultUseCase>();
        services.AddScoped<ISaveBatchOfAssessmentResultsUseCase, SaveBatchOfAssessmentResultsUseCase>();
        services.AddScoped<ISendAssessmentResultMailUseCase, SendAssessmentResultMailUseCase>();
        services.AddScoped<ISendBatchOfAssessmentResultMailsUseCase, SendBatchOfAssessmentResultMailsUseCase>();
        services.AddScoped<IUpdateAssessmentResultUseCase, UpdateAssessmentResultUseCase>();

        // Author
        services.AddScoped<IGetAllAuthorsUseCase, GetAllAuthorsUseCase>();

        // DocumentTemplate
        services.AddScoped<IAddDocumentTemplateUseCase, AddDocumentTemplateUseCase>();
        services.AddScoped<IFindDocumentTemplateUseCase, FindDocumentTemplateUseCase>();
        services.AddScoped<IFindOneDocumentTemplateUseCase, FindOneDocumentTemplateUseCase>();
        services.AddScoped<IGetAllDocumentTemplatesUseCase, GetAllDocumentTemplatesUseCase>();
        services.AddScoped<IGetDocumentTemplateUseCase, GetDocumentTemplateUseCase>();
        services.AddScoped<IGetLastDocumentTemplateUseCase, GetLastDocumentTemplateUseCase>();
        services.AddScoped<IRemoveDocumentTemplateUseCase, RemoveDocumentTemplateUseCase>();
        services.AddScoped<ISaveDocumentTemplateUseCase, SaveDocumentTemplateUseCase>();
        services.AddScoped<IUpdateDocumentTemplateUseCase, UpdateDocumentTemplateUseCase>();

        // EvaluationResult
        services.AddScoped<IAddEvaluationResultUseCase, AddEvaluationResultUseCase>();
        services.AddScoped<IFindEvaluationResultUseCase, FindEvaluationResultUseCase>();
        services.AddScoped<IFindOneEvaluationResultUseCase, FindOneEvaluationResultUseCase>();
        services.AddScoped<IGetAllEvaluationResultsUseCase, GetAllEvaluationResultsUseCase>();
        services.AddScoped<IGetEvaluationResultUseCase, GetEvaluationResultUseCase>();
        services.AddScoped<IRemoveEvaluationResultUseCase, RemoveEvaluationResultUseCase>();
        services.AddScoped<ISaveBatchOfEvaluationResultsUseCase, SaveBatchOfEvaluationResultsUseCase>();
        services.AddScoped<ISaveEvaluationResultUseCase, SaveEvaluationResultUseCase>();
        services.AddScoped<IUpdateEvaluationResultUseCase, UpdateEvaluationResultUseCase>();

        // Evaluator
        services.AddScoped<IAddEvaluatorUseCase, AddEvaluatorUseCase>();
        services.AddScoped<IFindEvaluatorUseCase, FindEvaluatorUseCase>();
        services.AddScoped<IFindOneEvaluatorUseCase, FindOneEvaluatorUseCase>();
        services.AddScoped<IGetAllEvaluatorsUseCase, GetAllEvaluatorsUseCase>();
        services.AddScoped<IGetAllNamesUseCase, GetAllNamesUseCase>();
        services.AddScoped<IGetAllNickNamesUseCase, GetAllNickNamesUseCase>();
        services.AddScoped<IGetEvaluatorUseCase, GetEvaluatorUseCase>();
        services.AddScoped<IRemoveEvaluatorUseCase, RemoveEvaluatorUseCase>();
        services.AddScoped<ISaveBatchOfEvaluatorsUseCase, SaveBatchOfEvaluatorsUseCase>();
        services.AddScoped<ISaveEvaluatorUseCase, SaveEvaluatorUseCase>();
        services.AddScoped<IUpdateEvaluatorUseCase, UpdateEvaluatorUseCase>();

        // Question
        services.AddScoped<IGetAllQuestionsUseCase, GetAllQuestionsUseCase>();

        // Raffle
        services.AddScoped<IMakeRaffleUseCase, MakeRaffleUseCase>();

        // Sortition
        services.AddScoped<IAddSortitionUseCase, AddSortitionUseCase>();
        services.AddScoped<IFindNameUseCase, FindNameUseCase>();
        services.AddScoped<IFindNickNameUseCase, FindNickNameUseCase>();
        services.AddScoped<IFindOutSortitionUseCase, FindOutSortitionUseCase>();
        services.AddScoped<IFindSortitionUseCase, FindSortitionUseCase>();
        services.AddScoped<IGetAllSortitionsUseCase, GetAllSortitionsUseCase>();
        services.AddScoped<IGetLastSortitionNumberUseCase, GetLastSortitionNumberUseCase>();
        services.AddScoped<IGetSortitionUseCase, GetSortitionUseCase>();
        services.AddScoped<IPrintSortitionUseCase, PrintSortitionUseCase>();
        services.AddScoped<ISaveSortitionUseCase, SaveSortitionUseCase>();
        services.AddScoped<IUpdateSortitionUseCase, UpdateSortitionUseCase>();

        // SortitionParticipant
        services.AddScoped<IAddSortitionParticipantUseCase, AddSortitionParticipantUseCase>();
        services.AddScoped<IConsultSortitionParticipantUseCase, ConsultSortitionParticipantUseCase>();
        services.AddScoped<IFindOneSortitionParticipantUseCase, FindOneSortitionParticipantUseCase>();
        services.AddScoped<IFindSortitionParticipantUseCase, FindSortitionParticipantUseCase>();
        services.AddScoped<IGetSortitionParticipantUseCase, GetSortitionParticipantUseCase>();
        services.AddScoped<ISaveSortitionParticipantUseCase, SaveSortitionParticipantUseCase>();
        services.AddScoped<IUpdateSortitionParticipantUseCase, UpdateSortitionParticipantUseCase>();

        // SortitionParticipant
        services.AddScoped<IAddSortitionParticipantPrintingUseCase, AddSortitionParticipantPrintingUseCase>();

        // Team
        services.AddScoped<IAddTeamUseCase, AddTeamUseCase>();
        services.AddScoped<IGetAllTeamsUseCase, GetAllTeamsUseCase>();
        services.AddScoped<IGetTeamUseCase, GetTeamUseCase>();
        services.AddScoped<IRemoveTeamUseCase, RemoveTeamUseCase>();
        services.AddScoped<ISaveTeamUseCase, SaveTeamUseCase>();
        services.AddScoped<IUpdateTeamUseCase, UpdateTeamUseCase>();
    }
}
