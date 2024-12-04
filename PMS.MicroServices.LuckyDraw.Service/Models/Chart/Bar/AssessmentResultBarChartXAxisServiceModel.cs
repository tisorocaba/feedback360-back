namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultBarChartXAxisServiceModel
{
    #region Constants
    const string TypeCategory = "category";
    #endregion Constants

    #region Properties
    public string Type { get; set; } = TypeCategory;
    public List<string> Data { get; set; } = new List<string>();
    #endregion Properties
}
