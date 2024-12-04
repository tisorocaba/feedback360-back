using Mapster;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class FindOneAssessmentResultUseCase
    : UseCaseBase,
    IFindOneAssessmentResultUseCase
{
    #region Constructors
    public FindOneAssessmentResultUseCase(IAssessmentResultDomainService assessmentResultDomainService)
    {
        this._assessmentResultDomainService = assessmentResultDomainService;
    }
    #endregion Constructors

    #region Fields
    private readonly IAssessmentResultDomainService _assessmentResultDomainService;
    #endregion Fields

    #region Methods
    public async Task<AssessmentResultUseCaseModel?> ExecuteAsync(Expression<Func<AssessmentResultUseCaseModel, bool>> expression)
    {
        var domainModel = await this._assessmentResultDomainService.FindOneAsync(expression.ConvertTo<AssessmentResultUseCaseModel, AssessmentResult, bool>());
        return domainModel?.Adapt<AssessmentResultUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
