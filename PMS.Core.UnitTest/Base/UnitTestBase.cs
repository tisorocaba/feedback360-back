using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PMS.Core.UnitTest.Fixtures.Base;
using PMS.Core.UnitTest.Fixtures.Interfaces;
using Xunit;

namespace PMS.Core.UnitTest.Base;

public abstract class UnitTestBase<TFixture>
    : IClassFixture<TFixture>
    where TFixture : ServiceProviderFixtureBase
{
    #region Constructors
    public UnitTestBase(IServiceProviderFixture fixture)
    {
        _configuration = fixture.Configuration;
        _serviceProvider = fixture.ServiceProvider;
    }
    #endregion Constructors

    #region Fields
    readonly IConfiguration _configuration;
    readonly ServiceProvider _serviceProvider;
    #endregion Fields

    #region Properties
    public IConfiguration Configuration { get { return _configuration; } }
    protected ServiceProvider ServiceProvider { get { return _serviceProvider; } }
    #endregion Properties
}
