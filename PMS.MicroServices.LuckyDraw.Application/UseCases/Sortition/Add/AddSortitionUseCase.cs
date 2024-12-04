using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.Core.Infra.CrossCutting.Utilities;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AddSortitionUseCase
    : UseCaseBase,
    IAddSortitionUseCase
{
    #region Constructors
    public AddSortitionUseCase(IFindSortitionUseCase findSortitionUseCase, IGetLastSortitionNumberUseCase getLastSortitionNumberUseCase,
                               ISortitionDomainService sortitionDomainService, IUpdateSortitionUseCase updateSortitionUseCase, IUnitOfWork unitOfWork)
    {
        this._findSortitionUseCase = findSortitionUseCase;
        this._getLastSortitionNumberUseCase = getLastSortitionNumberUseCase;
        this._sortitionDomainService = sortitionDomainService;
        this._updateSortitionUseCase = updateSortitionUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IFindSortitionUseCase _findSortitionUseCase;
    readonly IGetLastSortitionNumberUseCase _getLastSortitionNumberUseCase;
    readonly ISortitionDomainService _sortitionDomainService;
    readonly IUpdateSortitionUseCase _updateSortitionUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<Sortition?> ExecuteAsync(Sortition? model, bool commit = false)
    {
        Sortition? result = default;
        if ((model != null) && model.HasEmptyKey)
        {
            this.SetNumberIfNeeded(model);
            await this.InactivateTeamSortitions(model.IdTeam);

            result = await this._sortitionDomainService.SaveAsync(model);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
        return result;
    }

    public async Task<SortitionUseCaseModel?> ExecuteAsync(SortitionUseCaseModel? model, bool commit = false)
    {
        var result = await ExecuteAsync(model?.Adapt<Sortition>(this.AdapterConfig), commit);
        return result?.Adapt<SortitionUseCaseModel>(this.AdapterConfig);
    }

    private async Task InactivateTeamSortitions(Guid? idTeam)
    {
        if (idTeam.HasValue && (!TypeUtility.IsSetByDefault(idTeam.Value)))
        {
            Guid idSelectedTeam = idTeam.Value;
            var inactivatingSortitions = await this._findSortitionUseCase.ExecuteAsync(x => x.IdTeam == idSelectedTeam && x.Active);
            foreach (var currentInactivatingSortition in inactivatingSortitions)
            {
                currentInactivatingSortition.Active = false;
                await this._updateSortitionUseCase.ExecuteAsync(currentInactivatingSortition.Adapt<Sortition>(this.AdapterConfig));
            }
        }
    }

    private async void SetNumberIfNeeded(Sortition? model)
    {
        if ((model != null) && (model.Number <= 0))
        {
            var lastGeneratedNumber = await this._getLastSortitionNumberUseCase.ExecuteAsync();
            model.Number = (lastGeneratedNumber + 1);
        }
    }
    #endregion Methods
}
