namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultBarChartSerieServiceModel
{
    #region Constructors
    public AssessmentResultBarChartSerieServiceModel()
    {
        Data = new int[20];
    }

    public AssessmentResultBarChartSerieServiceModel(int length)
    {
        Data = new int[Math.Abs(length)];
    }
    #endregion Constructors

    #region Constants
    const string TypeBar = "bar", StackValue = "stack";
    #endregion Constants

    #region Properties
    public string Name { get; set; } = default!;
    public string Stack { get; set; } = StackValue;
    public string Type { get; set; } = TypeBar;
    public int[] Data { get; set; }
    #endregion Properties
}
