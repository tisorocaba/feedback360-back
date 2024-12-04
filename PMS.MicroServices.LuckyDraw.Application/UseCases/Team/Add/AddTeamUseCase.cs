using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AddTeamUseCase
    : UseCaseBase,
    IAddTeamUseCase
{
    #region Constructors
    public AddTeamUseCase(ITeamDomainService teamDomainService, IUnitOfWork unitOfWork)
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
    public async Task ExecuteAsync(TeamUseCaseModel? model, bool commit = false)
    {
        if ((model != null) && model.HasEmptyKey)
        {
            var domainModel = model.Adapt<Team>(this.AdapterConfig);

            await this._teamDomainService.SaveAsync(domainModel);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
