using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOneEvaluatorUseCase
    : UseCaseBase,
    IFindOneEvaluatorUseCase
{
    #region Constructors
    public FindOneEvaluatorUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<EvaluatorUseCaseModel?> ExecuteAsync(Expression<Func<EvaluatorUseCaseModel, bool>> expression)
    {
        var domainModel = await this._evaluatorDomainService.FindOneAsync(expression.ConvertTo<EvaluatorUseCaseModel, Evaluator, bool>())
                                                                   .ConfigureAwait(false);
        return domainModel?.Adapt<EvaluatorUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
