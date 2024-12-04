namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultBarChartLegendServiceModel
{
    #region Constructors
    public AssessmentResultBarChartLegendServiceModel()
    {
        this.Data = new List<string>(50);
    }
    #endregion Constructors

    #region Properties
    public List<string> Data { get; set; }
    #endregion Properties
}
