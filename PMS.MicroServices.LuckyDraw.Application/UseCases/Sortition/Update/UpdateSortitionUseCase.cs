using Mapster;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class UpdateSortitionUseCase
    : UseCaseBase,
    IUpdateSortitionUseCase
{
    #region Constructors
    public UpdateSortitionUseCase(ISortitionDomainService sortitionDomainService, IUnitOfWork unitOfWork)
    {
        this._sortitionDomainService = sortitionDomainService;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly ISortitionDomainService _sortitionDomainService;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<Sortition?> ExecuteAsync(Sortition? model, bool commit = false)
    {
        Sortition? result = default;
        if ((model != null) && (!model.HasEmptyKey))
        {
            result = await this._sortitionDomainService.SaveAsync(model);

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
        return result;
    }

    public async Task<SortitionUseCaseModel?> ExecuteAsync(SortitionUseCaseModel? model, bool commit = false)
    {
        var result = await this.ExecuteAsync(model?.Adapt<Sortition>(this.AdapterConfig), commit);
        return result?.Adapt<SortitionUseCaseModel>(this.AdapterConfig);
    }
    #endregion Methods
}
