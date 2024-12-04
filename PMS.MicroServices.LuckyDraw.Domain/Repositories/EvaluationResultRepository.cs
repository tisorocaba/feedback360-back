using PMS.MicroServices.LuckyDraw.Domain.DomainModels;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Base;
using PMS.MicroServices.LuckyDraw.Domain.Repositories.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

namespace PMS.MicroServices.LuckyDraw.Domain.Repositories;

public class EvaluationResultRepository
    : RepositoryBase<EvaluationResult, EvaluationResultDataModel, object, Guid>,
    IEvaluationResultRepository
{
    #region Constructors
    public EvaluationResultRepository(IEFCoreEvaluationResultDataModelRepository repository)
        : base(repository)
    {

    }
    #endregion Constructors
}
