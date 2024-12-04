namespace PMS.MicroServices.LuckyDraw.Service.Configurations;

public class LuckyDrawConfiguration
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
