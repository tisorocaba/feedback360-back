using System.Net;
using System.Net.Mail;
using System.Text;

namespace PMS.MicroServices.LuckyDraw.BoundedContexts.Networking.Services;

public class SmtpService
{
    #region Constructors
    public SmtpService(string? host)
    {
        this._encoding = Encoding.UTF8;
        this._smtpClient = new SmtpClient(host);
        this._smtpClient.SendCompleted += _smtpClient_SendCompleted;
    }
    #endregion Constructors

    #region Fields
    readonly Encoding _encoding;
    readonly SmtpClient _smtpClient;
    int _sendingResultsBufferSize = 8;
    Dictionary<string, bool>? _sendingResultsBuffer;
    MailMessage? _lastMailMessage;
    #endregion Fields

    #region Handlers
    private void _smtpClient_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        if (this._sendingResultsBuffer == null)
            this._sendingResultsBuffer = new Dictionary<string, bool>(this._sendingResultsBufferSize);

        var result = false;
        string? token = (string?)e.UserState;
        if (e.Cancelled)
            Console.WriteLine($"[{token}] {Resources.BoundedContextsNetworkingResource.CANCELED_SENDING_MAIL}");

        if (e.Error != null)
            Console.WriteLine($"[{token}] {e.Error}");
        else
        {
            Console.WriteLine(Resources.BoundedContextsNetworkingResource.SENT_MAIL_MESSAGE);
            result = true;
        }

        var taskId = e.UserState?.ToString();
        if ((!string.IsNullOrWhiteSpace(taskId)) && (!this._sendingResultsBuffer.ContainsKey(taskId)))
            this._sendingResultsBuffer.Add(taskId, result);
    }
    #endregion Handlers

    #region Methods
    public void Authenticate(string username, string password)
    {
        this._smtpClient.Credentials = new NetworkCredential(username, password);
    }

    private MailAddress BuildMailAddress(string address, string? name = null)
    {
        MailAddress mailAddress;
        if (!string.IsNullOrWhiteSpace(name))
            mailAddress = new MailAddress(address, name, this._encoding);
        else
            mailAddress = new MailAddress(address);
        return mailAddress;
    }

    private MailMessage CreateMailMessage(string fromAddress, string toAddress, string body, string? subject = null, bool? isBodyHtml = false, string? fromName = null)
    {
        var fromAddr = this.BuildMailAddress(fromAddress, fromName);
        var toAddr = this.BuildMailAddress(toAddress);
        var mailMessage = new MailMessage(fromAddr, toAddr);
        mailMessage.Body = body;
        mailMessage.BodyEncoding = this._encoding;
        mailMessage.Subject = subject;
        mailMessage.SubjectEncoding = this._encoding;
        mailMessage.IsBodyHtml = isBodyHtml ?? false;
        return mailMessage;
    }

    private string GenerateUserToken()
    {
        var random = new Random();
        return random.Next(1, int.MaxValue).ToString();
    }

    public bool GetSendingResult(string id)
    {
        if ((this._sendingResultsBuffer != null) && this._sendingResultsBuffer.ContainsKey(id))
            return this._sendingResultsBuffer[id];
        return false;
    }

    public void Send(string fromAddress, string toAddress, string body, string? subject = null, bool? isBodyHtml = false, string? fromName = null)
    {
        _lastMailMessage = this.CreateMailMessage(fromAddress, toAddress, body, subject, isBodyHtml, fromName);
        this._smtpClient.Send(_lastMailMessage);
    }

    public async Task<string> SendAsync(string fromAddress, string toAddress, string body, string? subject = null, bool? isBodyHtml = false, string? fromName = null)
    {
        var currentUserToken = this.GenerateUserToken();
        _lastMailMessage = this.CreateMailMessage(fromAddress, toAddress, body, subject, isBodyHtml, fromName);
        this._smtpClient.SendAsync(_lastMailMessage, currentUserToken);
        await Task.CompletedTask;
        return currentUserToken;
    }

    public async Task SendAsyncCancel()
    {
        this._smtpClient.SendAsyncCancel();
        await Task.CompletedTask;
    }

    public void SetByPass()
    {
        this._smtpClient.UseDefaultCredentials = true;
    }
    #endregion Methods

    #region Properties
    public int SendingResultsBufferSize
    {
        get { return this._sendingResultsBufferSize; }
        set
        {
            if (value != 0)
                this._sendingResultsBufferSize = Math.Abs(value);
        }
    }
    #endregion Properties
}
