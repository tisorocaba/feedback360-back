using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveSortitionUseCase
    : UseCaseBase,
    ISaveSortitionUseCase
{
    #region Constructors
    public SaveSortitionUseCase(IAddSortitionUseCase addSortitionUseCase, IGetSortitionUseCase getSortitionUseCase, IUpdateSortitionUseCase updateSortitionUseCase, IUnitOfWork unitOfWork)
    {
        this._addSortitionUseCase = addSortitionUseCase;
        this._getSortitionUseCase = getSortitionUseCase;
        this._updateSortitionUseCase = updateSortitionUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddSortitionUseCase _addSortitionUseCase;
    readonly IGetSortitionUseCase _getSortitionUseCase;
    readonly IUpdateSortitionUseCase _updateSortitionUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<Sortition?> ExecuteAsync(Sortition? model, bool commit = false)
    {
        Sortition? result = default;
        if (model != null)
        {
            if (model.HasEmptyKey)
                result = await this._addSortitionUseCase.ExecuteAsync(model, false);
            else
                result = await this._updateSortitionUseCase.ExecuteAsync(model, false);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
        return result;
    }

    public async Task<SortitionUseCaseModel?> ExecuteAsync(SortitionUseCaseModel? model, bool commit = false)
    {
        Sortition? result = default;
        if (model != null)
        {
            if (model.HasEmptyKey)
                result = await this.ExecuteAsync(model.Adapt<Sortition>(this.AdapterConfig), false);
            else
            {
                var useCaseModel = await this._getSortitionUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    result = await this.ExecuteAsync(model.Adapt<Sortition>(this.AdapterConfig), false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
        return result.Adapt<SortitionUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
