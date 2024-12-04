namespace PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Messages;

public class SendAssessmentResultMailRequestMessage
{
    #region Properties
    public string Name { get; set; } = default!;
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string Code { get; set; } = default!;
    public string? TargetUrl { get; set; }
    #endregion Properties
}
