using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PMS.Core.Infra.Data.MongoDB;
using PMS.Core.Infra.Data.MongoDB.Constants;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataContexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories;
using PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.MongoDB.IoC;

public class Bootstrapper
{
    public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(s => new MongoClient(configuration.GetValue<string>(CoreInfraDataMongoDbConstants.AppSettingsMongoDbConnectionString)));
        services.AddScoped<MongoDbOptionsLoader>();

        services.AddScoped<IDefaultMongoDbDataContext, DefaultMongoDbDataContext>();

        services.AddScoped<IAuthorMongoDbDataModelRepository, AuthorMongoDbDataModelRepository>();
        services.AddScoped<ICoWorkerMongoDbDataModelRepository, CoWorkerMongoDbDataModelRepository>();
        services.AddScoped<IGeneralQuestionMongoDbDataModelRepository, GeneralQuestionMongoDbDataModelRepository>();
        services.AddScoped<IImmediateLeaderMongoDbDataModelRepository, ImmediateLeaderMongoDbDataModelRepository>();
        services.AddScoped<ILeadershipQuestionMongoDbDataModelRepository, LeadershipQuestionMongoDbDataModelRepository>();
        services.AddScoped<IManagementQuestionMongoDbDataModelRepository, ManagementQuestionMongoDbDataModelRepository>();
        services.AddScoped<IManagementTeamMongoDbDataModelRepository, ManagementTeamMongoDbDataModelRepository>();
        services.AddScoped<IMediateLeaderMongoDbDataModelRepository, MediateLeaderMongoDbDataModelRepository>();
        services.AddScoped<ISelfAssessmentMongoDbDataModelRepository, SelfAssessmentMongoDbDataModelRepository>();
        services.AddScoped<ISubordinateMongoDbDataModelRepository, SubordinateMongoDbDataModelRepository>();
    }
}
