using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.Core.UnitTest.Fixtures.Interfaces;
using System.Reflection;

namespace PMS.Core.UnitTest.Fixtures.Base;

public abstract class ServiceProviderFixtureBase
    : IServiceProviderFixture
{
    #region Constructors
    public ServiceProviderFixtureBase()
    {
        var services = BuildServiceCollection();
        ConfigureCustomServices();
        ServiceProvider = services.BuildServiceProvider();
    }
    #endregion Constructors

    #region Fields
    ServiceCollection? _services;
    #endregion Fields

    #region Methods
    IConfigurationRoot BuildConfiguration()
    {
        string executingDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile($"{executingDirectory}\\{CoreInfraCrossCuttingConstants.AppSettingsDefaultJsonFile}");
        IConfigurationRoot configuration = builder.Build();
        return configuration;
    }

    ServiceCollection BuildServiceCollection()
    {
        Configuration = BuildConfiguration();
        _services = new ServiceCollection();
        _services.AddSingleton<IConfiguration>(Configuration);
        return _services;
    }

    protected abstract void ConfigureCustomServices();
    #endregion Methods

    #region Properties
    public IConfigurationRoot Configuration { get; private set; } = default!;
    public ServiceProvider ServiceProvider { get; private set; }
    protected ServiceCollection Services { get { return _services ?? new ServiceCollection(); } }
    #endregion Properties
}
