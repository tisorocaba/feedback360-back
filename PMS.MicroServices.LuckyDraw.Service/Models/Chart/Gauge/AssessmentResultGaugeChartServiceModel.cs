namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartServiceModel
{
    #region Constructors
    public AssessmentResultGaugeChartServiceModel()
    {
        this.Series = new List<AssessmentResultGaugeChartSerieServiceModel>();
    }
    #endregion Constructors

    #region Properties
    public AssessmentResultGaugeChartTitleServiceModel Title { get; set; } = new AssessmentResultGaugeChartTitleServiceModel();
    public AssessmentResultGaugeChartTooltipServiceModel Tooltip { get; set; } = new AssessmentResultGaugeChartTooltipServiceModel();
    public AssessmentResultGaugeChartLegendServiceModel Legend { get; set; } = new AssessmentResultGaugeChartLegendServiceModel();
    public List<AssessmentResultGaugeChartSerieServiceModel> Series { get; set; }
    #endregion Properties
}
