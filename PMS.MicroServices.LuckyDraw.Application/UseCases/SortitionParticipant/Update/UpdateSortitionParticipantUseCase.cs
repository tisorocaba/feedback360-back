using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateSortitionParticipantUseCase
    : UseCaseBase,
    IUpdateSortitionParticipantUseCase
{
    #region Constructors
    public UpdateSortitionParticipantUseCase(ISortitionParticipantDomainService sortitionParticipantDomainService, IUnitOfWork unitOfWork)
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
    public async Task<SortitionParticipant?> ExecuteAsync(SortitionParticipant? model, bool commit = false)
    {
        SortitionParticipant? result = default!;
        if ((model != null) && (!model.HasEmptyKey))
        {
            result = await this._sortitionParticipantDomainService.SaveAsync(model);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
        return result;
    }

    public async Task<SortitionParticipantUseCaseModel?> ExecuteAsync(SortitionParticipantUseCaseModel? model, bool commit = false)
    {
        var result = await this.ExecuteAsync(model?.Adapt<SortitionParticipant>(this.AdapterConfig), commit);
        return result?.Adapt<SortitionParticipantUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
