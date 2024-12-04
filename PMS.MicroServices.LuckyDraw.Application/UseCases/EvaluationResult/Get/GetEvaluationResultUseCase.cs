using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetEvaluationResultUseCase
    : UseCaseBase,
    IGetEvaluationResultUseCase
{
    #region Constructors
    public GetEvaluationResultUseCase(IEvaluationResultDomainService evaluationResultDomainService)
    {
        this._evaluationResultDomainService = evaluationResultDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluationResultDomainService _evaluationResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<EvaluationResultUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._evaluationResultDomainService.GetByIdAsync(id).ConfigureAwait(false);
        return domainModel?.Adapt<EvaluationResultUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
