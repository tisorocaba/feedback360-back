namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartItemStyleServiceModel
{
    #region Constants
    const string DefaultShadowColor = "rgba(0, 0, 0, 0.5)";
    #endregion Constants

    #region Properties
    public int ShadowBlur { get; set; } = 10;
    public int ShadowOffsetX { get; set; } = 0;
    public string ShadowColor { get; set; } = DefaultShadowColor;
    #endregion Properties
}
