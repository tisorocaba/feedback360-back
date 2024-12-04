using PMS.Core.Infra.Data.DataModels.Base;

namespace PMS.Core.Infra.Data.EFCore.DataModels;

public class EFCoreCompositeKeyDataModelBase
    : DataModelBase<object>
{
    #region Properties
    public override object Id { get; set; } = default!;
    #endregion Properties
}
