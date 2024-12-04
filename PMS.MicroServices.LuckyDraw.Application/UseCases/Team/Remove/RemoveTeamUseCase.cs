using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class RemoveTeamUseCase
    : IRemoveTeamUseCase
{
    #region Constructors
    public RemoveTeamUseCase(ITeamDomainService teamDomainService, IUnitOfWork unitOfWork)
    {
        this._teamDomainService = teamDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly ITeamDomainService _teamDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(Guid id, bool commit = false)
    {
        if (!TypeUtility.IsSetByDefault(id))
        {
            var domainModel = await this._teamDomainService.GetByIdAsync(id);

            if (domainModel != null)
                await this._teamDomainService.RemoveAsync(id);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
