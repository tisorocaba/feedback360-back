using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveSortitionParticipantUseCase
    : UseCaseBase,
    ISaveSortitionParticipantUseCase
{
    #region Constructors
    public SaveSortitionParticipantUseCase(IAddSortitionParticipantUseCase addSortitionParticipantUseCase,
                                           IGetSortitionParticipantUseCase getSortitionParticipantUseCase,
                                           IUpdateSortitionParticipantUseCase updateSortitionParticipantUseCase, IUnitOfWork unitOfWork)
    {
        this._addSortitionParticipantUseCase = addSortitionParticipantUseCase;
        this._getSortitionParticipantUseCase = getSortitionParticipantUseCase;
        this._updateSortitionParticipantUseCase = updateSortitionParticipantUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddSortitionParticipantUseCase _addSortitionParticipantUseCase;
    readonly IGetSortitionParticipantUseCase _getSortitionParticipantUseCase;
    readonly IUpdateSortitionParticipantUseCase _updateSortitionParticipantUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(SortitionParticipant? model, bool commit = false)
    {
        if (model != null)
        {
            if (model.HasEmptyKey)
                await this._addSortitionParticipantUseCase.ExecuteAsync(model, false);
            else
                await this._updateSortitionParticipantUseCase.ExecuteAsync(model, false);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }

    public async Task ExecuteAsync(SortitionParticipantUseCaseModel? model, bool commit = false)
    {
        if (model != null)
        {
            if (model.HasEmptyKey)
                await this.ExecuteAsync(model.Adapt<SortitionParticipant>(this.AdapterConfig), false);
            else
            {
                var useCaseModel = await this._getSortitionParticipantUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    await this.ExecuteAsync(model.Adapt<SortitionParticipant>(this.AdapterConfig), false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
