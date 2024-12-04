using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class EvaluationResultItemRepository
    : RepositoryBase<EvaluationResultItem, EvaluationResultItemDataModel, object, Guid>,
    IEvaluationResultItemRepository
{
    #region Constructors
    public EvaluationResultItemRepository(IEFCoreEvaluationResultItemDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
