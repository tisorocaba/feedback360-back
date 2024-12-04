using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateEvaluationResultUseCase
    : UseCaseBase,
    IUpdateEvaluationResultUseCase
{
    #region Constructors
    public UpdateEvaluationResultUseCase(IEvaluationResultDomainService evaluationResultDomainService, IUnitOfWork unitOfWork)
    {
        this._evaluationResultDomainService = evaluationResultDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluationResultDomainService _evaluationResultDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<EvaluationResultUseCaseModel?> ExecuteAsync(EvaluationResultUseCaseModel? model, bool commit = false)
    {
        EvaluationResult? result = default!;
        if ((model != null) && (!model.HasEmptyKey))
        {
            var domainModel = model.Adapt<EvaluationResult>(this.AdapterConfig);

            result = await this._evaluationResultDomainService.SaveAsync(domainModel).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
        return result?.Adapt<EvaluationResultUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
