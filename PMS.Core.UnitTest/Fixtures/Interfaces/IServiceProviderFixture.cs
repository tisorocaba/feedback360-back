using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PMS.Core.UnitTest.Fixtures.Interfaces;

public interface IServiceProviderFixture
{
    #region Properties
    IConfigurationRoot Configuration { get; }
    ServiceProvider ServiceProvider { get; }
    #endregion Properties
}
