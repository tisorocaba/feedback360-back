namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartTooltipServiceModel
{
    #region Constants
    const string TriggerItem = "item";
    #endregion Constants

    #region Properties
    public string? Trigger { get; set; } = TriggerItem;
    #endregion Properties
}
