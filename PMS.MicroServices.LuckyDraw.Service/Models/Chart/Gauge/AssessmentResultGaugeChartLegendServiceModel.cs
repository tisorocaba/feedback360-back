namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartLegendServiceModel
{
    #region Constants
    const string BottomSide = "bottom", LeftSide = "left", OrientationHorizontal = "horizontal", OrientationVertical = "vertical";
    #endregion Constants

    #region Properties
    public string? Orient { get; set; } = OrientationHorizontal;
    public string? Left { get; set; } = BottomSide;
    #endregion Properties
}
