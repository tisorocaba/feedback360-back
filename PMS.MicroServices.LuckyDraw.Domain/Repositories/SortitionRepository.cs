using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class SortitionRepository
    : RepositoryBase<Sortition, SortitionDataModel, object, Guid>,
    ISortitionRepository
{
    #region Constructors
    public SortitionRepository(IEFCoreSortitionDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
