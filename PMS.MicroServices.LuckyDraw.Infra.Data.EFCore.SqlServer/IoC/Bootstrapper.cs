using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.Contexts;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services)
    {
        EFCore.IoC.Bootstrapper.ConfigureServices(services);

        services.AddScoped<IDbContext, AppSqlServerDbContext>();

        services.AddScoped<IEFCoreAssessmentResultDataModelRepository, EFCoreAssessmentResultDataModelRepository>();
        services.AddScoped<IEFCoreDocumentTemplateDataModelRepository, EFCoreDocumentTemplateDataModelRepository>();
        services.AddScoped<IEFCoreEvaluationResultItemDataModelRepository, EFCoreEvaluationResultItemDataModelRepository>();
        services.AddScoped<IEFCoreEvaluationResultDataModelRepository, EFCoreEvaluationResultDataModelRepository>();
        services.AddScoped<IEFCoreEvaluatorDataModelRepository, EFCoreEvaluatorDataModelRepository>();
        services.AddScoped<IEFCoreQuestionDataModelRepository, EFCoreQuestionDataModelRepository>();
        services.AddScoped<IEFCoreSortitionDataModelRepository, EFCoreSortitionDataModelRepository>();
        services.AddScoped<IEFCoreSortitionParticipantDataModelRepository, EFCoreSortitionParticipantDataModelRepository>();
        services.AddScoped<IEFCoreSortitionParticipantPrintingDataModelRepository, EFCoreSortitionParticipantPrintingDataModelRepository>();
        services.AddScoped<IEFCoreTeamDataModelRepository, EFCoreTeamDataModelRepository>();
    }
}
