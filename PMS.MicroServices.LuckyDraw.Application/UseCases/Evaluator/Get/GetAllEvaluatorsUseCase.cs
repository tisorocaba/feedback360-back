using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllEvaluatorsUseCase
    : UseCaseBase,
    IGetAllEvaluatorsUseCase
{
    #region Constructors
    public GetAllEvaluatorsUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<EvaluatorUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<EvaluatorUseCaseModel, object> orderByCreatedAt = EvaluatorUseCaseExpressions.CreatedAtOrderByAscending;
        var domainModels = await this._evaluatorDomainService.GetAllAsync(orderByCreatedAt.ConvertTo<EvaluatorUseCaseModel, Evaluator, object>())
                                                             .ConfigureAwait(false);
        var useCaseModels = new List<EvaluatorUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<EvaluatorUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
