using PMS.Core.Infra.Data.EFCore.Contexts.Interfaces;
using PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.DataModels;

namespace PMS.MicroServices.LuckyDraw.Infra.Data.EFCore.SqlServer.DataModelRepositories.Interfaces;

public interface IEFCoreSortitionParticipantPrintingDataModelRepository
    : IEFCoreDataModelRepository<SortitionParticipantPrintingDataModel, Guid>
{

}
