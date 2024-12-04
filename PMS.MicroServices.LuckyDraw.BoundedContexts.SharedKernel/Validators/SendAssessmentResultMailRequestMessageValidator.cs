using FluentValidation;
using PMS.Core.Infra.CrossCutting.Constants;
using PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Messages;
using System.Text.RegularExpressions;

namespace PMS.MicroServices.LuckyDraw.BoundedContexts.SharedKernel.Validators;

public class SendAssessmentResultMailRequestMessageValidator
    : AbstractValidator<SendAssessmentResultMailRequestMessage>
{
    #region Constructors
    public SendAssessmentResultMailRequestMessageValidator()
    {
        RuleFor(u => u.Email).Custom((val, context) =>
        {
            if (!string.IsNullOrWhiteSpace(val))
            {
                var regexEmail = new Regex(CoreInfraCrossCuttingConstants.RegexForEmailDomainWithTLD);
                if (!regexEmail.IsMatch(val))
                    context.AddFailure(context.PropertyPath, Resources.BoundedContextsSharedKernelResource.EMAIL_INVALID);
            }
        });

        RuleFor(u => u.Name).Custom((val, context) =>
        {
            if (string.IsNullOrWhiteSpace(val))
                context.AddFailure(context.PropertyPath, Resources.BoundedContextsSharedKernelResource.NAME_INVALID);
        });

        RuleFor(u => u.Code).Custom((val, context) =>
        {
            if (string.IsNullOrWhiteSpace(val))
                context.AddFailure(context.PropertyPath, Resources.BoundedContextsSharedKernelResource.CODE_INVALID);
        });
    }
    #endregion Constructors
}
