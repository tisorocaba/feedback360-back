﻿using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AddSortitionParticipantUseCase
    : UseCaseBase,
    IAddSortitionParticipantUseCase
{
    #region Constructors
    public AddSortitionParticipantUseCase(ISortitionParticipantDomainService sortitionParticipantDomainService, IUnitOfWork unitOfWork)
    {
        this._sortitionParticipantDomainService = sortitionParticipantDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionParticipantDomainService _sortitionParticipantDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(SortitionParticipant? model, bool commit = false)
    {
        if ((model != null) && model.HasEmptyKey)
        {
            await this._sortitionParticipantDomainService.SaveAsync(model);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }

    public async Task ExecuteAsync(SortitionParticipantUseCaseModel? model, bool commit = false)
    {
        await this.ExecuteAsync(model?.Adapt<SortitionParticipant>(this.AdapterConfig), commit);
    }
    #endregion Methods
}