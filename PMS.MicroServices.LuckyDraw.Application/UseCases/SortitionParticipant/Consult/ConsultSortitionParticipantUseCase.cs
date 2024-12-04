using PMS.Core.Infra.CrossCutting.Cryptography.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.ExtensionMethods;
using PMS.Core.Infra.CrossCutting.UoW.Interfaces;
using PMS.MicroServices.LuckyDraw.Application.Base;
using PMS.MicroServices.LuckyDraw.Application.Models;
using System.Linq.Expressions;

namespace PMS.MicroServices.LuckyDraw.Application.UseCases;

public class ConsultSortitionParticipantUseCase
    : UseCaseBase,
    IConsultSortitionParticipantUseCase
{
    #region Constructors
    public ConsultSortitionParticipantUseCase(IFindOneSortitionParticipantUseCase findOneSortitionParticipantUseCase,
                                              IUpdateSortitionParticipantUseCase updateSortitionParticipantUseCase, IUnitOfWork unitOfWork)
    {
        this._findOneSortitionParticipantUseCase = findOneSortitionParticipantUseCase;
        this._updateSortitionParticipantUseCase = updateSortitionParticipantUseCase;
        this._unitOfWork = unitOfWork;
    }
    #endregion Constructors

    #region Fields
    private readonly IFindOneSortitionParticipantUseCase _findOneSortitionParticipantUseCase;
    private readonly IUpdateSortitionParticipantUseCase _updateSortitionParticipantUseCase;
    private readonly IUnitOfWork _unitOfWork;
    #endregion Fields

    #region Methods
    public async Task<SortitionConsultResponseMessage?> ExecuteAsync(int participantNumber, string code, int? pSortitionNumber = null, Guid? pIdTeam = null,
                                                                      bool commit = true)
    {
        SortitionParticipantUseCaseModel? result = default!;
        if ((participantNumber > 0) && (!string.IsNullOrWhiteSpace(code)))
        {
            var encryptedCode = code.EncryptDES(DESExtensionMethods.Default_DES_Key, DESExtensionMethods.Default_DES_IV);
            Expression<Func<SortitionParticipantUseCaseModel, bool>> expression = x => (x.Number == participantNumber) && (x.Code == encryptedCode);

            if (pSortitionNumber.HasValue)
            {
                int sortitionNumber = pSortitionNumber.Value;
                Expression<Func<SortitionParticipantUseCaseModel, bool>> exp1 = x => x.Sortition.Number == sortitionNumber;
                expression.AndAlsoExpression(exp1);
            }

            if (pIdTeam.HasValue)
            {
                Guid idTeam = pIdTeam.Value;
                Expression<Func<SortitionParticipantUseCaseModel, bool>> exp2 = x => x.Sortition.IdTeam == idTeam;
                expression.AndAlsoExpression(exp2);
            }

            var useCaseModel = await this._findOneSortitionParticipantUseCase.ExecuteAsync(expression);
            if (useCaseModel != null)
            {
                useCaseModel.AccessCounter = (useCaseModel.AccessCounter + 1);
                result = await this._updateSortitionParticipantUseCase.ExecuteAsync(useCaseModel, false);

                if (commit)
                    await this._unitOfWork.CommitAsync();
            }
        }
        return result?.ToConsultResponse();
    }
    #endregion Methods
}
