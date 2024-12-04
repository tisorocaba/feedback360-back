namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartTitleServiceModel
{
    #region Constants
    const string CenterSide = "center";
    #endregion Constants

    #region Properties
    public string? Text { get; set; }
    public string? Subtext { get; set; }
    public string? Left { get; set; } = CenterSide;
    #endregion Properties
}
