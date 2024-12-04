using Microsoft.Extensions.Configuration;
using Winton.Extensions.Configuration.Consul;

namespace PMS.Core.Adapters.Consul.ExtensionMethods;

public static class ConfigurationManagerExtensionMethods
{
    public static IConfigurationBuilder? ConfigureConsul(this ConfigurationManager configurationManager, string key, string url, bool optional = true, bool reloadOnChange = true,
                                                        double pollWaitTime = 5, double retryWaitTime = 2)
    {
        try
        {
            return configurationManager.AddConsul(key, options =>
            {
                options.ConsulConfigurationOptions = cco => { cco.Address = new Uri(url); };
                options.Optional = optional;
                options.PollWaitTime = TimeSpan.FromSeconds(pollWaitTime);
                options.ReloadOnChange = reloadOnChange;
                options.OnLoadException = (consulLoadExceptionContext) =>
                {
                    Console.WriteLine(string.Format(Resources.CoreAdaptersConsulResource.CONFIGURE_CONSUL_ON_LOAD_EXCEPTION,
                                                    consulLoadExceptionContext.Exception.Message,
                                                    consulLoadExceptionContext.Exception.StackTrace));
                    throw consulLoadExceptionContext.Exception;
                };
                options.OnWatchException = (consulWatchExceptionContext) =>
                {
                    Console.WriteLine(string.Format(Resources.CoreAdaptersConsulResource.CONFIGURE_CONSUL_ON_WATCH_EXCEPTION, consulWatchExceptionContext.Exception.Message));
                    return TimeSpan.FromSeconds(retryWaitTime);
                };
            });
        }
        catch { return null; }
    }
}
