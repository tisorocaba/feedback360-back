using PMS.Core.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;

public interface ISubordinateDomainService
    : IDomainService<Subordinate, Guid>
{
    #region Methods
    public void SetGeneralQuestions(List<GeneralQuestion> questions);
    #endregion Methods
}
