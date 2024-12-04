using Microsoft.Extensions.DependencyInjection;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services)
    {
        Infra.Data.EFCore.SqlServer.IoC.Bootstrapper.ConfigureServices(services);
        //Core.Adapters.RabbitMQ.IoC.Bootstrapper.ConfigureServices(services);

        services.AddScoped<IAssessmentResultDomainService, AssessmentResultDomainService>();
        services.AddScoped<IAssessmentResultRepository, AssessmentResultRepository>();
        services.AddScoped<IAuthorDomainService, AuthorDomainService>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICoWorkerDomainService, CoWorkerDomainService>();
        services.AddScoped<ICoWorkerRepository, CoWorkerRepository>();
        services.AddScoped<IDocumentTemplateDomainService, DocumentTemplateDomainService>();
        services.AddScoped<IDocumentTemplateRepository, DocumentTemplateRepository>();
        services.AddScoped<IEvaluationResultDomainService, EvaluationResultDomainService>();
        services.AddScoped<IEvaluationResultRepository, EvaluationResultRepository>();
        services.AddScoped<IEvaluationResultItemDomainService, EvaluationResultItemDomainService>();
        services.AddScoped<IEvaluationResultItemRepository, EvaluationResultItemRepository>();
        services.AddScoped<IEvaluatorDomainService, EvaluatorDomainService>();
        services.AddScoped<IEvaluatorRepository, EvaluatorRepository>();
        services.AddScoped<IGeneralQuestionDomainService, GeneralQuestionDomainService>();
        services.AddScoped<IGeneralQuestionRepository, GeneralQuestionRepository>();
        services.AddScoped<IImmediateLeaderDomainService, ImmediateLeaderDomainService>();
        services.AddScoped<IImmediateLeaderRepository, ImmediateLeaderRepository>();
        services.AddScoped<ILeadershipQuestionDomainService, LeadershipQuestionDomainService>();
        services.AddScoped<ILeadershipQuestionRepository, LeadershipQuestionRepository>();
        services.AddScoped<IManagementQuestionDomainService, ManagementQuestionDomainService>();
        services.AddScoped<IManagementQuestionRepository, ManagementQuestionRepository>();
        services.AddScoped<IManagementTeamDomainService, ManagementTeamDomainService>();
        services.AddScoped<IManagementTeamRepository, ManagementTeamRepository>();
        services.AddScoped<IMediateLeaderDomainService, MediateLeaderDomainService>();
        services.AddScoped<IMediateLeaderRepository, MediateLeaderRepository>();
        services.AddScoped<IQuestionDomainService, QuestionDomainService>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ISelfAssessmentDomainService, SelfAssessmentDomainService>();
        services.AddScoped<ISelfAssessmentRepository, SelfAssessmentRepository>();
        services.AddScoped<ISortitionDomainService, SortitionDomainService>();
        services.AddScoped<ISortitionRepository, SortitionRepository>();
        services.AddScoped<ISortitionParticipantDomainService, SortitionParticipantDomainService>();
        services.AddScoped<ISortitionParticipantRepository, SortitionParticipantRepository>();
        services.AddScoped<ISortitionParticipantPrintingDomainService, SortitionParticipantPrintingDomainService>();
        services.AddScoped<ISortitionParticipantPrintingRepository, SortitionParticipantPrintingRepository>();
        services.AddScoped<ISortitionResultDomainService, SortitionResultDomainService>();
        services.AddScoped<ISubordinateDomainService, SubordinateDomainService>();
        services.AddScoped<ISubordinateRepository, SubordinateRepository>();
        services.AddScoped<ITeamDomainService, TeamDomainService>();
        services.AddScoped<ITeamRepository, TeamRepository>();

        //services.AddScoped<IRabbitMQDomainService, RabbitMQDomainService>();
    }
}
