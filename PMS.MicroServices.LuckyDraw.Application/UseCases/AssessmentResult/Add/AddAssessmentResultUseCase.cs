using Mapster;
using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.Security;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AddAssessmentResultUseCase
    : UseCaseBase,
    IAddAssessmentResultUseCase
{
    #region Constructors
    public AddAssessmentResultUseCase(IAssessmentResultDomainService assessmentResultDomainService, IUnitOfWork unitOfWork)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
        this._unitOfWork = unitOfWork;
        this._passwordGenerator = new PasswordGenerator();
    }
    #endregion Constructors

    #region Fields
    readonly IAssessmentResultDomainService _assessmentResultDomainService;
    readonly IUnitOfWork _unitOfWork;
    readonly PasswordGenerator _passwordGenerator;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false)
    {
        if ((model != null) && model.HasEmptyKey)
        {
            var domainModel = model.Adapt<AssessmentResult>(this.AdapterConfig);
            domainModel.Code = this._passwordGenerator.GenerateHexadecimal().EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);

            await this._assessmentResultDomainService.SaveAsync(domainModel);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
