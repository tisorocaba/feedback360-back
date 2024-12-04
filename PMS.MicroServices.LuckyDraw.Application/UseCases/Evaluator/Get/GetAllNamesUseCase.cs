using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllNamesUseCase
    : UseCaseBase,
    IGetAllNamesUseCase
{
    #region Constructors
    public GetAllNamesUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<NameUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<EvaluatorUseCaseModel, object> orderByName = EvaluatorUseCaseExpressions.NameOrderByAscending;
        Expression<Func<Evaluator, bool>> expression = (e => (!string.IsNullOrEmpty(e.Name)));
        var domainModels = await this._evaluatorDomainService.FindAsync(expression, orderByName.ConvertTo<EvaluatorUseCaseModel, Evaluator, object>());
        var useCaseModels = new List<NameUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<NameUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
