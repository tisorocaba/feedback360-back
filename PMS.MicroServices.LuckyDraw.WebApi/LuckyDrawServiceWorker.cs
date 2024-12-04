using PMS.MicroServices.LuckyDraw.Service.Constants;

namespace PMS.MicroServices.LuckyDraw.WebApi;

public class LuckyDrawServiceWorker : BackgroundService
{
    #region Constructors
    public LuckyDrawServiceWorker(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<LuckyDrawServiceWorker>();
    }
    #endregion Constructors

    #region Fields
    public ILogger _logger { get; }
    #endregion Fields

    #region Methods
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(LuckyDrawServiceConstants.WindowsServiceStartingMessage);

        stoppingToken.Register(() => _logger.LogInformation(LuckyDrawServiceConstants.WindowsServiceStoppingMessage));

        while (!stoppingToken.IsCancellationRequested)
        {
            //_logger.LogInformation(LdapServiceConstants.WindowsServiceWorkingMessage);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }

        _logger.LogInformation(LuckyDrawServiceConstants.WindowsServiceStoppedMessage);
    }
    #endregion Methods
}
