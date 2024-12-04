using Mapster;
using PMS.Core.Infra.CrossCutting.Expressions;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Expressions;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class GetAllAssessmentResultsUseCase
    : UseCaseBase,
    IGetAllAssessmentResultsUseCase
{
    #region Constructors
    public GetAllAssessmentResultsUseCase(IAssessmentResultDomainService assessmentResultDomainService)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
    }
    #endregion Constructors

    #region Fields
    readonly IAssessmentResultDomainService _assessmentResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<List<AssessmentResultUseCaseModel>> ExecuteAsync()
    {
        OrderByExpression<AssessmentResultUseCaseModel, object> orderByCreatedAt = AssessmentResultUseCaseExpressions.NameOrderByAscending;
        var domainModels = await this._assessmentResultDomainService.GetAllAsync(orderByCreatedAt.ConvertTo<AssessmentResultUseCaseModel, AssessmentResult, object>());
        var useCaseModels = new List<AssessmentResultUseCaseModel>(domainModels.Count());
        domainModels.ToList().ForEach(e => useCaseModels.Add(e.Adapt<AssessmentResultUseCaseModel>(this.AdapterConfig)));
        return useCaseModels;
    }
    #endregion Methods
}
