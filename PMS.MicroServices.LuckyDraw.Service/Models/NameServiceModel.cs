using PMS.Core.Service.Base;

namespace PMS.MicroServices.LuckyDraw.Service.Models;

public class NameServiceModel
    : AuditableServiceModelBase<Guid>
{
    #region Properties
    public string? Name { get; set; }
    #endregion Properties
}
