﻿using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateEvaluatorUseCase
    : UseCaseBase,
    IUpdateEvaluatorUseCase
{
    #region Constructors
    public UpdateEvaluatorUseCase(IEvaluatorDomainService evaluatorDomainService, IUnitOfWork unitOfWork)
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
    public async Task<EvaluatorUseCaseModel?> ExecuteAsync(EvaluatorUseCaseModel? model, bool commit = false)
    {
        Evaluator? result = default!;
        if ((model != null) && (!model.HasEmptyKey))
        {
            var domainModel = model.Adapt<Evaluator>(this.AdapterConfig);

            result = await this._evaluatorDomainService.SaveAsync(domainModel).ConfigureAwait(false);

            if (commit)
                await this._unitOfWork.CommitAsync().ConfigureAwait(false);
        }
        return result?.Adapt<EvaluatorUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}