using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Constants;
using PMS.MicroServices.LuckyDraw.BoundedContexts.Networking.Services;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Messages;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Models;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Validators;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SendAssessmentResultMailUseCase
    : UseCaseBase,
    ISendAssessmentResultMailUseCase
{
    #region Constructors
    public SendAssessmentResultMailUseCase(IGetLastDocumentTemplateUseCase getLastDocumentTemplateUseCase)
    {
        this._getLastDocumentTemplateUseCase = getLastDocumentTemplateUseCase;
        this._sendPasswordRecoveryValidator = new SendAssessmentResultMailRequestMessageValidator();
    }
    #endregion Constructors

    #region Fields
    readonly IGetLastDocumentTemplateUseCase _getLastDocumentTemplateUseCase;
    readonly SendAssessmentResultMailRequestMessageValidator _sendPasswordRecoveryValidator;
    #endregion Fields

    #region Methods
    private string BindHtmlBody(DocumentTemplateUseCaseModel documentTemplate, string email, string name, string code, string? targetUrl)
    {
        return documentTemplate?.Content?.Replace(LuckyDrawApplicationConstants.CodeWorkspace, code.DecryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV))
                                         .Replace(LuckyDrawApplicationConstants.EmailWorkspace, email)
                                         .Replace(LuckyDrawApplicationConstants.NameWorkspace, name)
                                         .Replace(LuckyDrawApplicationConstants.TargetUrlWorkspace, targetUrl ?? string.Empty) ?? string.Empty;
    }
    #endregion Methods

    #region Tasks
    public async Task<SendAssessmentResultMailResponseMessage> ExecuteAsync(LuckyDrawAppConfiguration config, SendAssessmentResultMailRequestMessage requestMessage)
    {
        SendAssessmentResultMailResponseMessage responseMessage = new SendAssessmentResultMailResponseMessage() { Succeed = false };
        var validationResult = this._sendPasswordRecoveryValidator.Validate(requestMessage);
        if (validationResult.IsValid)
        {
            var lastDocumentTemplate = await this._getLastDocumentTemplateUseCase.ExecuteAsync();
            if (lastDocumentTemplate != null)
            {
                var email = requestMessage.Email ?? string.Empty;
                if (!string.IsNullOrWhiteSpace(email))
                {
                    var htmlBody = this.BindHtmlBody(lastDocumentTemplate, email, requestMessage.Name, requestMessage.Code, requestMessage.TargetUrl);
                    try
                    {
                        var smtpService = new SmtpService(config.MailingHost);
                        smtpService.Authenticate(config.MailingUserName, config.MailingPassword);
                        smtpService.Send(config.MailingFromAddress, email, htmlBody, config.MailingSubject, true, config.MailingFromName);
                        responseMessage.Succeed = true;
                        responseMessage.Message = Resources.LuckyDrawApplicationResource.EMAIL_SENT;
                    }
                    catch (Exception ex) { responseMessage.Message = ex.Message; }
                }
            }
            else
                responseMessage.Message = Resources.LuckyDrawApplicationResource.DOCUMENT_TEMPLATE_NOT_FOUND;
        }
        else
            responseMessage.Message = validationResult.Errors?.ToString() ?? string.Empty;
        return responseMessage;
    }
    #endregion Tasks
}
