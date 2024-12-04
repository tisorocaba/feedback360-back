using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class RemoveEvaluationResultUseCase
    : IRemoveEvaluationResultUseCase
{
    #region Constructors
    public RemoveEvaluationResultUseCase(IEvaluationResultDomainService evaluationResultDomainService, IUnitOfWork unitOfWork)
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
    public async Task ExecuteAsync(Guid id, bool commit = false)
    {
        if (!TypeUtility.IsSetByDefault(id))
        {
            var domainModel = await this._evaluationResultDomainService.GetByIdAsync(id).ConfigureAwait(false);

            if (domainModel != null)
                await this._evaluationResultDomainService.RemoveAsync(id).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
    #endregion Methods
}
