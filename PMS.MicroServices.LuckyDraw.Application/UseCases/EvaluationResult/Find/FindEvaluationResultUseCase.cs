using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindEvaluationResultUseCase
    : UseCaseBase,
    IFindEvaluationResultUseCase
{
    #region Constructors
    public FindEvaluationResultUseCase(IEvaluationResultDomainService evaluationResultDomainService)
    {
        this._evaluationResultDomainService = evaluationResultDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluationResultDomainService _evaluationResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<EvaluationResultUseCaseModel>> ExecuteAsync(Expression<Func<EvaluationResultUseCaseModel, bool>> expression)
    {
        OrderByExpression<EvaluationResultUseCaseModel, object> orderByCreatedAt = EvaluationResultUseCaseExpressions.CreatedAtOrderByAscending;
        var domainModels = await this._evaluationResultDomainService.FindAsync(expression.ConvertTo<EvaluationResultUseCaseModel, EvaluationResult, bool>(),
                                                                               orderByCreatedAt.ConvertTo<EvaluationResultUseCaseModel, EvaluationResult, object>())
                                                             .ConfigureAwait(false);
        var useCaseModels = new List<EvaluationResultUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<EvaluationResultUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
