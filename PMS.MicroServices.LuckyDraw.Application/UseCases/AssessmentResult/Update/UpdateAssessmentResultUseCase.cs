using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateAssessmentResultUseCase
    : UseCaseBase,
    IUpdateAssessmentResultUseCase
{
    #region Constructors
    public UpdateAssessmentResultUseCase(IAssessmentResultDomainService assessmentResultDomainService, IUnitOfWork unitOfWork)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAssessmentResultDomainService _assessmentResultDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(AssessmentResultUseCaseModel? model, bool commit = false)
    {
        if ((model != null) && (!model.HasEmptyKey))
        {
            var domainModel = model.Adapt<AssessmentResult>(this.AdapterConfig);

            await this._assessmentResultDomainService.SaveAsync(domainModel);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
