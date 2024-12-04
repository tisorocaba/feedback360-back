using PMS.Core.Domain.DomainServices.Base;
using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.DomainServices.Interfaces;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.DomainServices;

public class AuthorDomainService
    : DomainServiceBase<Author, Guid>,
    IAuthorDomainService
{
    #region Constructors
    public AuthorDomainService(IAuthorRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
