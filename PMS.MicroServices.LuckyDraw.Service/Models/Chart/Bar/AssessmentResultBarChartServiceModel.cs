namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultBarChartServiceModel
{
    #region Constants
    public AssessmentResultBarChartServiceModel()
    {
        this.Series = new List<AssessmentResultBarChartSerieServiceModel>();
        this.Color = new List<string>(AssessmentResultChartHelper.HexColors.Length);
    }
    #endregion Constants

    #region Properties
    public string TargetName { get; set; } = default!;
    public List<string> Color { get; set; } = default!;
    public AssessmentResultBarChartLegendServiceModel Legend { get; set; } = new AssessmentResultBarChartLegendServiceModel();
    public AssessmentResultBarChartXAxisServiceModel XAxis { get; set; } = new AssessmentResultBarChartXAxisServiceModel();
    public AssessmentResultBarChartYAxisServiceModel YAxis { get; set; } = new AssessmentResultBarChartYAxisServiceModel();
    public List<AssessmentResultBarChartSerieServiceModel> Series { get; set; }
    #endregion Properties
}
