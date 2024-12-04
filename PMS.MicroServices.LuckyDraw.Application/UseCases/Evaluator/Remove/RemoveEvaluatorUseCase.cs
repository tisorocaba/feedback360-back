using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class RemoveEvaluatorUseCase
    : IRemoveEvaluatorUseCase
{
    #region Constructors
    public RemoveEvaluatorUseCase(IEvaluatorDomainService evaluatorDomainService, IUnitOfWork unitOfWork)
    {
        this._evaluatorDomainService = evaluatorDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IEvaluatorDomainService _evaluatorDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(Guid id, bool commit = false)
    {
        if (!TypeUtility.IsSetByDefault(id))
        {
            var domainModel = await this._evaluatorDomainService.GetByIdAsync(id).ConfigureAwait(false);

            if (domainModel != null)
                await this._evaluatorDomainService.RemoveAsync(id).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
    }
    #endregion Methods
}
