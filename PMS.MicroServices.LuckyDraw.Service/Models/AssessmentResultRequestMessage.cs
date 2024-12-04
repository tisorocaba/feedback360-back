namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class AssessmentResultRequestMessage
{
    #region Properties
    public string NickName { get; set; } = default!;
    public string UserNameOrEmail { get; set; } = default!;
    public string Code { get; set; } = default!;
    public string? EvaluatedPersonName { get; set; }
    #endregion Properties
}
