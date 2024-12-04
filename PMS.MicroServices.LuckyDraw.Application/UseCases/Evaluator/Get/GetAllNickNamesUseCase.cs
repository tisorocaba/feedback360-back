using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllNickNamesUseCase
    : UseCaseBase,
    IGetAllNickNamesUseCase
{
    #region Constructors
    public GetAllNickNamesUseCase(IEvaluatorDomainService evaluatorDomainService)
    {
        this._evaluatorDomainService = evaluatorDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<NickNameUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<EvaluatorUseCaseModel, object> orderByNickName = EvaluatorUseCaseExpressions.NickNameOrderByAscending;
        Expression<Func<Evaluator, bool>> expression = (e => (!string.IsNullOrEmpty(e.NickName)));
        var domainModels = await this._evaluatorDomainService.FindAsync(expression, orderByNickName.ConvertTo<EvaluatorUseCaseModel, Evaluator, object>());
        var useCaseModels = new List<NickNameUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<NickNameUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
