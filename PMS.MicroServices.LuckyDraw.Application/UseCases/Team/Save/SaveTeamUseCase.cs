using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class SaveTeamUseCase
    : UseCaseBase,
    ISaveTeamUseCase
{
    #region Constructors
    public SaveTeamUseCase(IAddTeamUseCase addTeamUseCase, IGetTeamUseCase getTeamUseCase, IUpdateTeamUseCase updateTeamUseCase, IUnitOfWork unitOfWork)
    {
        this._addTeamUseCase = addTeamUseCase;
        this._getTeamUseCase = getTeamUseCase;
        this._updateTeamUseCase = updateTeamUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    readonly IAddTeamUseCase _addTeamUseCase;
    readonly IGetTeamUseCase _getTeamUseCase;
    readonly IUpdateTeamUseCase _updateTeamUseCase;
    readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task ExecuteAsync(TeamUseCaseModel? model, bool commit = false)
    {
        if (model != null)
        {
            if (model.HasEmptyKey)
                await this._addTeamUseCase.ExecuteAsync(model, false);
            else
            {
                var useCaseModel = await this._getTeamUseCase.ExecuteAsync(model.Id);
                if (useCaseModel != null)
                {
                    model.Bind(useCaseModel);
                    await this._updateTeamUseCase.ExecuteAsync(model, false);
                }
            }

            if (commit)
                await this._unitOfWork.CommitAsync();
        }
    }
    #endregion Methods
}
