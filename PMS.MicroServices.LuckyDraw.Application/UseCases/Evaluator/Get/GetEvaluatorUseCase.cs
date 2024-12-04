using Mapster;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetEvaluatorUseCase
    : UseCaseBase,
    IGetEvaluatorUseCase
{
    #region Constructors
    public GetEvaluatorUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<EvaluatorUseCaseModel?> ExecuteAsync(Guid id)
    {
        var domainModel = await this._evaluatorDomainService.GetByIdAsync(id).ConfigureAwait(false);
        return domainModel?.Adapt<EvaluatorUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
