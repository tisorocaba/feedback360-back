using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAssessmentResultUseCase
    : UseCaseBase,
    IGetAssessmentResultUseCase
{
    #region Constructors
    public GetAssessmentResultUseCase(IAssessmentResultDomainService assessmentResultDomainService)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IAssessmentResultDomainService _assessmentResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<AssessmentResultUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._assessmentResultDomainService.GetByIdAsync(id);
        return domainModel?.Adapt<AssessmentResultUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
