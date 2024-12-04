namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultGaugeChartSerieServiceModel
{
    #region Constructors
    public AssessmentResultGaugeChartSerieServiceModel()
    {
        this.Data = new List<AssessmentResultGaugeChartSerieItemDataServiceModel>();
    }
    #endregion Constructors

    #region Constants
    const string TypePie = "pie";
    const string RadiusHalfPercent = "50%";
    #endregion Constants

    #region Properties
    public string? Name { get; set; }
    public string? Type { get; set; } = TypePie;
    public string? Radius { get; set; } = RadiusHalfPercent;
    public List<AssessmentResultGaugeChartSerieItemDataServiceModel> Data { get; set; }
    public AssessmentResultGaugeChartSerieEmphasisServiceModel Emphasis { get; set; } = new AssessmentResultGaugeChartSerieEmphasisServiceModel();
    #endregion Properties
}
