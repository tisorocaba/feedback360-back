using Mapster;
using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMLDD = PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class MakeRaffleUseCase
    : UseCaseBase,
    IMakeRaffleUseCase
{
    #region Constructors
    public MakeRaffleUseCase(IGetTeamUseCase getTeamUseCase, ISaveSortitionUseCase saveSortitionUseCase)
    {
        this._getTeamUseCase = getTeamUseCase;
        this._saveSortitionUseCase = saveSortitionUseCase;
    }
    #endregion Constructors

    #region Fields
    private readonly IGetTeamUseCase _getTeamUseCase;
    private readonly ISaveSortitionUseCase _saveSortitionUseCase;
    #endregion Fields

    #region Methods
    private SortitionUseCaseModel? DecryptParticipanteCode(SortitionUseCaseModel? model)
    {
        if (model?.Participants?.Any() ?? false)
        {
            foreach (var currentParticipant in model.Participants)
                currentParticipant.Code = currentParticipant.Code.DecryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            //model.Participants.Sort(new SortitionParticipantUseCaseModelComparer());
        }
        return model;
    }

    public async Task<SortitionUseCaseModel?> ExecuteAsync(int rows, int columns = 3)
    {
        var luckyDraw = new PMLDD.LuckyDraw();
        Sortition sortition;
        do
        {
            sortition = luckyDraw.Raffle(rows, columns);
        } while (!sortition.IsValid);
        var result = await this._saveSortitionUseCase.ExecuteAsync(sortition, true);
        return this.DecryptParticipanteCode(result?.Adapt<SortitionUseCaseModel>(this.AdapterConfig));
    }

    public async Task<SortitionUseCaseModel?> ExecuteTeamAsync(Guid idTeam, int columns = 3)
    {
        Sortition? result = default;
        var useCaseModel = await this._getTeamUseCase.ExecuteAsync(idTeam);
        if (useCaseModel != null)
        {
            var luckyDraw = new PMLDD.LuckyDraw();
            Sortition sortition;
            do
            {
                sortition = luckyDraw.RaffleForTeam(useCaseModel.Adapt<Team>(this.AdapterConfig), columns);
            } while (!sortition.IsValid);
            result = await this._saveSortitionUseCase.ExecuteAsync(sortition, true);
        }
        return this.DecryptParticipanteCode(result?.Adapt<SortitionUseCaseModel>(this.AdapterConfig));
    }
    #endregion Methods
}
