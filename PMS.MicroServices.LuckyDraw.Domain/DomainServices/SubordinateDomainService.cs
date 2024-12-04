using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class SubordinateDomainService
    : DomainServiceBase<Subordinate, Guid>,
    ISubordinateDomainService
{
    #region Constructors
    public SubordinateDomainService(ISubordinateRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors

    #region Properties
    public void SetGeneralQuestions(List<GeneralQuestion> questions)
    {
        ((ISubordinateRepository)this.Repository).Questions = questions;
    }
    #endregion Properties
}
