using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllQuestionsUseCase
    : UseCaseBase,
    IGetAllQuestionsUseCase
{
    #region Constructors
    public GetAllQuestionsUseCase(IQuestionDomainService questionDomainService)
    {
        this._questionDomainService = questionDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IQuestionDomainService _questionDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<QuestionUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<QuestionUseCaseModel, object> abbreviationByCreatedAt = QuestionUseCaseExpressions.AbbreviationOrderByAscending;
        var domainModels = await this._questionDomainService.GetAllAsync(abbreviationByCreatedAt.ConvertTo<QuestionUseCaseModel, Question, object>())
                                                            .ConfigureAwait(false);
        var useCaseModels = new List<QuestionUseCaseModel>(domainModels.Count());
        domainModels.OrderBy(m => m.Abbreviation).ToList().ForEach(e => useCaseModels.Add(e.Adapt<QuestionUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
