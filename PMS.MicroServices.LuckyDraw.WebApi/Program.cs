using Mapster;
using PMS.Core.Adapters.Consul.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Service.Configurations;
using PMS.MicroServices.LuckyDraw.Service.Constants;
using PMS.MicroServices.LuckyDraw.Service.Resources;
using PMS.MicroServices.LuckyDraw.WebApi;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

string configurationRepositoryUrl = Environment.GetEnvironmentVariable(LuckyDrawServiceConstants.EnvironmentVariableConfigurationRepositoryUrl) ?? string.Empty;
bool consulConfigurationEnabled = TypeUtility.ConvertToBoolean(Environment.GetEnvironmentVariable(LuckyDrawServiceConstants.EnvironmentVariableConsulConfigurationEnabled));
string consulConfigurationKey = Environment.GetEnvironmentVariable(LuckyDrawServiceConstants.EnvironmentVariableConsulConfigurationKey) ?? string.Empty;

var builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder? configBuilder = null;

try
{
    if (consulConfigurationEnabled && (!string.IsNullOrWhiteSpace(configurationRepositoryUrl)) && (!string.IsNullOrWhiteSpace(consulConfigurationKey)))
        configBuilder = builder.Configuration.ConfigureConsul(consulConfigurationKey, configurationRepositoryUrl);
}
catch { }

if (configBuilder == null)
    configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                              .AddJsonFile(CoreInfraCrossCuttingConstants.AppSettingsDefaultJsonFile);
else
    Console.WriteLine(string.Format(LuckyDrawServiceResource.CONSUL_CONFIGURATION_LOADED, consulConfigurationKey, configurationRepositoryUrl));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    );
});

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve)
                .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => options.IdleTimeout = TimeSpan.FromMinutes(1));

builder.Services.AddScoped<LuckyDrawConfigurationLoader>();

PMS.MicroServices.LuckyDraw.Service.IoC.Bootstrapper.ConfigureServices(builder.Services, builder.Configuration);

TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);

var cultureInfo = new CultureInfo(CoreInfraCrossCuttingConstants.CulturePortugueseBrazil);
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

if ((!Debugger.IsAttached) && RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Host.UseWindowsService()
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile(LuckyDrawServiceConstants.WindowsServiceJsonAppSettings);
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<LuckyDrawServiceWorker>();
                });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.MapControllers();

app.Run();
