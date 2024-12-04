using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOneEvaluationResultUseCase
    : UseCaseBase,
    IFindOneEvaluationResultUseCase
{
    #region Constructors
    public FindOneEvaluationResultUseCase(IEvaluationResultDomainService evaluationResultDomainService)
    {
        this._evaluationResultDomainService = evaluationResultDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluationResultDomainService _evaluationResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<EvaluationResultUseCaseModel?> ExecuteAsync(Expression<Func<EvaluationResultUseCaseModel, bool>> expression)
    {
        var domainModel = await this._evaluationResultDomainService.FindOneAsync(expression.ConvertTo<EvaluationResultUseCaseModel, EvaluationResult, bool>())
                                                                   .ConfigureAwait(false);
        return domainModel?.Adapt<EvaluationResultUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
