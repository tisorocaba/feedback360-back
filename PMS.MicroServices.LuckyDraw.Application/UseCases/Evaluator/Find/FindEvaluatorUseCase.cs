using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindEvaluatorUseCase
    : UseCaseBase,
    IFindEvaluatorUseCase
{
    #region Constructors
    public FindEvaluatorUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<EvaluatorUseCaseModel>> ExecuteAsync(Expression<Func<EvaluatorUseCaseModel, bool>> expression)
    {
        OrderByExpression<EvaluatorUseCaseModel, object> orderByCreatedAt = EvaluatorUseCaseExpressions.CreatedAtOrderByAscending;
        var domainModels = await this._evaluatorDomainService.FindAsync(expression.ConvertTo<EvaluatorUseCaseModel, Evaluator, bool>(),
                                                                        orderByCreatedAt.ConvertTo<EvaluatorUseCaseModel, Evaluator, object>())
                                                             .ConfigureAwait(false);
        var useCaseModels = new List<EvaluatorUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<EvaluatorUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
