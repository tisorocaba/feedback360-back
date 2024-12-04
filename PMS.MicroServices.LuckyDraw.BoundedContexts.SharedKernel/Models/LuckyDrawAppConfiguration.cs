namespace PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;

public class LuckyDrawAppConfiguration
{
    #region Properties
    public string MailingHost = default!;
    public int MailingPort = 25;
    public string MailingUserName = default!;
    public string MailingPassword = default!;
    public string MailingFromAddress = default!;
    public string MailingFromName = default!;
    public string MailingSubject = default!;
    #endregion Properties
}
