using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class AddSortitionParticipantPrintingUseCase
    : UseCaseBase,
    IAddSortitionParticipantPrintingUseCase
{
    #region Constructors
    public AddSortitionParticipantPrintingUseCase(ISortitionParticipantPrintingDomainService sortitionParticipantPrintingDomainService, IUnitOfWork unitOfWork)
    {
        this._sortitionParticipantPrintingDomainService = sortitionParticipantPrintingDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionParticipantPrintingDomainService _sortitionParticipantPrintingDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(SortitionParticipantPrinting? model, bool commit = false)
    {
        if ((model != null) && model.HasEmptyKey)
        {
            await this._sortitionParticipantPrintingDomainService.SaveAsync(model);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }

    public async Task ExecuteAsync(SortitionParticipantPrintingUseCaseModel? model, bool commit = false)
    {
        await this.ExecuteAsync(model?.Adapt<SortitionParticipantPrinting>(this.AdapterConfig), commit);
    }
    #endregion Methods
}
