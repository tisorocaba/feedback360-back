using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class ConsultAssessmentResultUseCase
    : UseCaseBase,
    IConsultAssessmentResultUseCase
{
    #region Constructors
    public ConsultAssessmentResultUseCase(IFindOneAssessmentResultUseCase findOneAssessmentResultUseCase)
    {
        this._findOneAssessmentResultUseCase = findOneAssessmentResultUseCase;
    }
    #endregion Constructors

    #region Fields
    private readonly IFindOneAssessmentResultUseCase _findOneAssessmentResultUseCase;
    #endregion Fields

    #region Methods
    public async Task<AssessmentResultUseCaseModel?> ExecuteAsync(string userNameOrEmail, string code)
    {
        AssessmentResultUseCaseModel? useCaseModel;
        if ((!string.IsNullOrWhiteSpace(userNameOrEmail)) && (!string.IsNullOrWhiteSpace(code)))
        {
            var encryptedCode = code.EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            Expression<Func<AssessmentResultUseCaseModel, bool>> expression = x => (((x.Email == userNameOrEmail) || (x.Name == userNameOrEmail)) && 
                                                                                     (x.Code == encryptedCode));
            useCaseModel = await this._findOneAssessmentResultUseCase.ExecuteAsync(expression);
        }
        else
            useCaseModel = default;
        return useCaseModel;
    }
    #endregion Methods
}
